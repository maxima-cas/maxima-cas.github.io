/* --------------------------------------------------
Compute the line integral of fn along the path path
for parameter values from p0 to p1.
fn   is an expression,
path a list of two or three equations, one for each
     coordinate. The left hand sides of the equations
     are the names of the coordinates, the right
     hand sides are expressions in  param

 ---------------------------------------------------*/
lineIntegral(fn, path, param, p0, p1) :=
 block ( [substitutedFn, x, xx],
         substitutedFn: sublis(path, fn),
         x : ev (substitutedFn, diff),
         xx: subst(1, Diff(param), x),
         Integrate(xx, param, p0, p1) 
       )$

