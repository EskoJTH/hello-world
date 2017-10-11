#lang slideshow
(define c (circle 10))
(define r (rectangle 10 20))
(define (four p)
  (define two-p (hc-append p p))
  (vc-append two-p two-p))
(define (checker p1 p2)
  (let ([p12 (hc-append p1 p2)]
        [p21 (hc-append p2 p1)])
    (vc-append p12 p21)))
(define (square n)
  ; A semi-colon starts a line comment.
  ; The expression below is the function body.
  (filled-rectangle n n))
(define myfun)
