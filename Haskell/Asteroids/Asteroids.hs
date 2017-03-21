

module Main where
import Control.Monad (join)
import Data.Bifunctor (bimap)
import Graphics.Gloss
import Graphics.Gloss.Interface.Pure.Game
import Graphics.Gloss.Interface.Pure.Simulate
import Graphics.Gloss.Interface.Pure.Display
import Graphics.Gloss.Data.Picture

data AsteroidWorld = Play [Rock] Ship UFO [Bullet]
                   | GameOver 
                   deriving (Eq,Show)

type Velocity     = (Float, Float)
type Size         = Float
type Age          = Float



data Ship   = Ship   PointInSpace Velocity
    deriving (Eq,Show)
data Bullet = Bullet PointInSpace Velocity Age
    deriving (Eq,Show)
data Rock   = Rock   PointInSpace Size Velocity
    deriving (Eq,Show)
data UFO   = UFO PointInSpace Size  Velocity
    deriving (Eq,Show)

initialWorld :: AsteroidWorld
initialWorld = Play
                   [Rock (150,150)  45 (2,6)
                   ,Rock (-45,201)  45 (13,-8)
                   ,Rock (45,22)    25 (-2,8)
                   ,Rock (-210,-15) 30 (-2,-8)
                   ,Rock (-45,-201) 25 (8,2) 
                   ] 
                   (Ship (0,0) (0,5)) 
                   (UFO (40,50) 25 (13,45))--My UFO
                   [] 


simulateWorld :: Float -> (AsteroidWorld -> AsteroidWorld)

simulateWorld _ GameOver = GameOver

simulateWorld timeStep (Play rocks (Ship shipPos shipV) ufo  bullets)
  | any (collidesWith shipPos) rocks = GameOver
  | otherwise = Play (concatMap updateRock rocks)
                (Ship newShipPos shipV)
                (updateUFO ufo)
                (concat (map updateBullet bullets))
  where
      collidesWith :: PointInSpace -> Rock -> Bool
      collidesWith p (Rock rp s _)
       = magV (rp .- p) < s

      collidesWithU :: PointInSpace -> UFO -> Bool
      collidesWithU p (UFO rp s _)
       = magV (rp .- p) < s

      collidesWithBullet :: Rock -> Bool
      collidesWithBullet r
       = any (\(Bullet bp _ _) -> collidesWith bp r) bullets

      collidesWithUFO :: UFO -> Bool
      collidesWithUFO r
       = any (\(Bullet bp _ _) -> collidesWithU bp r) bullets
         
      updateRock :: Rock -> [Rock]
      updateRock r@(Rock p s v) 
       | collidesWithBullet r && s < 7 
            = []
       | collidesWithBullet r && s > 7 
            = splitRock r
       | otherwise                     
            = [Rock (restoreToScreen (p .+ timeStep .* v)) s v]

      updateUFO :: UFO -> UFO
      updateUFO r@(UFO p s v)
       | collidesWithUFO r
            = UFO (restoreToScreen (p .+ timeStep .* join bimap (negate) v)) s (join bimap (negate) v) 
       | otherwise                     
            = UFO (restoreToScreen (p .+ timeStep .* v)) s v
 
      updateBullet :: Bullet -> [Bullet] 
      updateBullet (Bullet p v a) 
        | a > 5                      
             = []
        | any (collidesWith p) rocks 
             = [] 
        | otherwise                  
             = [Bullet (restoreToScreen (p .+ timeStep .* v)) v 
                       (a + timeStep)] 

      newShipPos :: PointInSpace
      newShipPos = restoreToScreen (shipPos .+ timeStep .* shipV)

splitRock :: Rock -> [Rock]
splitRock (Rock p s v) = [Rock p (s/2) (3 .* rotateV (pi/3)  v)
                         ,Rock p (s/2) (3 .* rotateV (-pi/3) v) ]

restoreToScreen :: PointInSpace -> PointInSpace
restoreToScreen (x,y) = (cycleCoordinates x, cycleCoordinates y)

cycleCoordinates :: (Ord a, Num a) => a -> a
cycleCoordinates x 
    | x < (-400) = 800+x
    | x > 400    = x-800
    | otherwise  = x

drawWorld :: Picture->Picture->Picture->AsteroidWorld ->  Picture

drawWorld _ _ _ GameOver 
   = scale 0.3 0.3 
     . translate (-400) 0 
     . color red 
     . text 
     $ "Game Over!"

drawWorld rocket rock bullet (Play rocks (Ship (x,y) (vx,vy)) (UFO (p1,p2) s v) bullets)
  = pictures [ship, asteroids,shots,ufo]
   where
    ship      = pictures [translate x y (rocket)]
    asteroids = pictures [translate x y (rock)
                         | Rock   (x,y) s _ <- rocks]
    shots     = pictures [translate x y ((bullet))
                         | Bullet (x,y) _ _ <- bullets]
    ufo       = pictures [translate p1 p2 (rocket)]



handleEvents :: Event -> AsteroidWorld -> AsteroidWorld

handleEvents (EventKey (MouseButton LeftButton) Down _ clickPos)
             GameOver
             = initialWorld

handleEvents _ GameOver = GameOver

handleEvents (EventKey (MouseButton LeftButton) Down _ clickPos)
             (Play rocks (Ship shipPos shipVel) ufo bullets)
             = Play rocks (Ship shipPos newVel) 
                          ufo (newBullet : bullets)
 where 
     newBullet = Bullet shipPos 
                        (-150 .* norm (shipPos .- clickPos)) 
                        0
     newVel    = shipVel .+ (50 .* norm (shipPos .- clickPos))

handleEvents _ w = w

type PointInSpace = (Float, Float)
(.-) , (.+) :: PointInSpace -> PointInSpace -> PointInSpace
(x,y) .- (u,v) = (x-u,y-v)
(x,y) .+ (u,v) = (x+u,y+v)

(.*) :: Float -> PointInSpace -> PointInSpace
s .* (u,v) = (s*u,s*v)

infixl 6 .- , .+
infixl 7 .*

norm :: PointInSpace -> PointInSpace
norm (x,y) = let m = magV (x,y) in (x/m,y/m)

magV :: PointInSpace -> Float
magV (x,y) = sqrt (x**2 + y**2) 

limitMag :: Float -> PointInSpace -> PointInSpace
limitMag n pt = if (magV pt > n) 
                  then n .* (norm pt)
                  else pt

rotateV :: Float -> PointInSpace -> PointInSpace
rotateV r (x,y) = (x * cos r - y * sin r
                  ,x * sin r + y * cos r)

main :: IO ()
main =
  loadBMP "Rocket1.bmp" >>= \rocket -> 
  loadBMP "Bullet1.bmp" >>= \bullet ->
  loadBMP "Rock1.bmp" >>= \rock ->
  play 
         (InWindow "Asteroids!" (550,550) (20,20)) 
         black
         24
         initialWorld 
         (drawWorld rocket rock bullet)
         handleEvents
         simulateWorld

     -- do pictures [rocket, ...]
     -- do rocket <- ask
     --    pictures [rocket, ...]

