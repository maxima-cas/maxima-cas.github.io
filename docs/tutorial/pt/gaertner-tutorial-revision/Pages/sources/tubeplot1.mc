
/*------------------------------
for Maxima 5.9.1
computation of a tube around a spacial curve.
This version does not simplify intermediate results.
----------------------------*/
rotateLeft(v1):= append(rest(v1, 1), cons(first(v1), []))$
cross (u, v) := rotateLeft( u * rotateLeft(v) - v * rotateLeft(u))$

tangent(fn, x) :=
       Diff(fn(x), x) / ((Diff(fn(x), x) . Diff(fn (x), x))^(1/2))$

binormal (fn, x) := 
         cross (Diff(fn(x), x), 
                 Diff (fn(x), x, 2)
                 ) / 
              (( cross(Diff(fn(x), x), Diff (fn(x), x, 2))
               . cross(Diff(fn(x), x), Diff (fn(x), x, 2))
                ) ^(1/2))$
normal (fn, x) := cross(binormal(fn, x), tangent(fn, x))$


 tube(fn, r, t, phi) :=
       fn(t) + r* (cos(phi)* normal(fn, t) + sin(phi)* binormal(fn, t))$


