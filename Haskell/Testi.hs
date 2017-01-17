area shape diameter
  | shape == "circle" = pi * (diameter/2)**2
  | shape == "square" = diameter / sqrt 2
  | otherwise         = -1