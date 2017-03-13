module JSON where


class JSON a where
  toJSONString :: JSON a => a -> String
  
