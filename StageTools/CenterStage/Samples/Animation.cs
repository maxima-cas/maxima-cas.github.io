#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Animation.cs
#  Created:  Fri Nov 12 09:48:09 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Polyhedron Create Fractal-Koch {
  {#
#  We use a separate window for our controls.
#  The frame is so we can raise the border for
#  the checkbox and center it.  The checkbox
#  causes the evolver to be reset.
#
Window Koch
Frame K1 -in Koch -at \{0 1\} -relief raised -bd 2
Evolve n \{Step(n)\} -reset Reset() -in Koch -at \{0 0\}
CheckBox fullT 0 -title \"Full Snowflake\" \\
  -in K1 -at \{0 0\} \\
  -command \{Self Evolver n Reset; Update\}

#
#  The initial edge(s) to be subdivided
#
set FullE \{
  \{\{0 0 0\} \{1 0 0\}\}
  \{\{1 0 0\} \{.5 -0.8660254 0\}\}
  \{\{.5 -0.8660254 0\} \{0 0 0\}\}
\}
set LineE \{
  \{\{0 0 0\} \{1 0 0\}\}
\}

set nMax 4; # too slow for beyond this

#
#  To reset, save the initial edges in
#  the current edge list.  Return 0 so
#  that n will be set to 0 steps.
#

proc Reset \{\} \{
  variables fullT E FullE LineE
  if \{$fullT\} \{set E $FullE\} else \{set E $LineE\}
  return 0
\}

#
#  Check if the computation would be too long
#  For each edge in the old set
#    Get the endpoints
#    Find the points that trisect the edge
#    Find the unit vector along the edge
#      (the vector (-b,a,0) is perpendicular to it)
#    Find the tip of the triangle to be added
#    Add the four new edges to the list
#  Make the new list the current list
#  If we have reached the maximum steps, stop
#    (use \"after 0\" so that the buttons won't
#     be reset until after the computation 
#     completes.)
#
proc Step \{n\} \{
  variables E nMax
  if \{[incr n] > $nMax\} \\
    \{error \"Too slow to compute beyond step $nMax\"\}
  set EE \{\}
  foreach edge $E \{
    let (p0,p1) = edge
    let p2 = (2p0 + p1) / 3
    let p3 = (p0 + 2p1) / 3
    let U = p1 - p0
    let (a,b,c) = Unit(U)
    let p4 = Norm(U) (sqrt(3)/6) (-b,a,0) \\
       + (p0 + p1) / 2
    lappend EE [list $p0 $p2]
    lappend EE [list $p2 $p4]
    lappend EE [list $p4 $p3]
    lappend EE [list $p3 $p1]
  \}
  set E $EE
  if \{$n >= $nMax\} \{after 0 \"[Self] Evolver n Stop\"\}
  return $n
\}

#
#  Make sure edge list exists initially
#
variable E; Reset

#
#  The face list has embedded vertices
#  (rather than refering to the Vertices
#  list) and has no \"<-\" commands.  I.e.,
#  the list is entirely precomputed.
#
Precomputed -faces -flist
Faces \{$E\}
}
  {selected 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}

####################

::class::Polyhedron Create Fractal-Sierpinski {
  {Evolve n Step(n) -reset Reset()

#
#  The initial triangle
#

let InitialT = \{
  \{(0,0,0) (1,0,0) (1/2,sqrt(3)/2,0)\}
\}


set nMax 5;# too slow to do more

#
#  To reset, set the triangle list
#  to the initial triangle list and
#  return 0 as initial n
#

proc Reset \{\} \{
  variables T InitialT
  set T [list $InitialT]
  return 0
\}

#
#  Check if we've gone too far
#  For each triangle in the old set
#    Get the endpoints
#    Find the midpoints of the edges
#    Add the new triangles to the list
#  Make the new list the current list
#  If we are at the maximum n, stop
#    (use \"after 0\" to prevent buttons
#     from changing until after the
#     computation completes)
#    
proc Step \{n\} \{
  variables T nMax
  if \{[incr n] > $nMax\} \\
    \{Error \"Too slow to compute past $nMax iterations\"\}
  set TT \{\}
  foreach triangle $T \{
    let (p0,p1,p2) = triangle
    let p01 = (p0+p1)/2
    let p12 = (p1+p2)/2
    let p02 = (p0+p2)/2
    lappend TT [list $p0 $p01 $p02]
    lappend TT [list $p1 $p12 $p01]
    lappend TT [list $p2 $p02 $p12]
  \}
  set T $TT
  if \{$n == $nMax\} \{after 0 \"[Self] Evolver n Stop\"\}
  return $n
\}

#
#  Make sure this is set initially
#
set T [list $InitialT]

#
#  The face list has embedded vertices
#  (no references to Vertices list)
#  and does not use \"<-\" syntax
#
Precomputed -faces -flist
Faces \{$T\}
}
  {selected 1 each}
  {{::_color::Function RGB=XYZ} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Root-Bisection {
  {#
#  Implements the bisection method of root
#  finding.  You get to specify the function
#  and the starting positions for the
#  search (a and b).  These must be such
#  that f(a) and f(b) have opposite signs.
#

Window controls -rows \{1 1\} -columns \{1 1\} \\
  -title \"Bisection\"
Frame inputs -in controls -at \{0 0 1 2\} \\
  -rows \{1 1 1 1\} -columns 1 -relief raised -bd 2
Frame output -in controls -at \{1 0\} -bg grey70 \\
  -rows \{1 1\} -columns 1 -relief raised -bd 2


TypeIn f \"x^3-3x+1\" -title \"f(x) =\" -in inputs -at \{0 0\} -titlewidth 8
TypeIn D \"(-2,2,100)\" -title \"Domain:\" -evaluate -in inputs -at \{0 1\} -titlewidth 8
Frame ab -in inputs -at \{0 2\} -rows 1 -columns \{1 1\}
TypeIn a \"-1\" -evaluate -width 6 -in ab -at \{0 0\}
TypeIn b \"1\" -evaluate -width 6 -in ab -at \{1 0\}
TypeIn e \".01\" -evaluate -title \"Max error:\" -in inputs -at \{0 3\}

#
#  The function's value at x
#
proc F \{x\} \{
  variable f
  let y = ($f)
  return $y
\}

#
#  This is used to tell the evolver
#  that the setup has changed and the
#  process needs to be reset
#
set NeedsReset 0

#
#  Get the initial values of f at a and b
#  And check that they are of opposite
#  signs (the error is done using \"after\" 
#  so that the function will be displayed
#  anyway -- this makes it easier to choose
#  appropriate values for a and b).
#
#  We also get the values of the domain
#  and indicate to the Evolver that it
#  will need to be reset.
#
Setup \{
  let fa = F(a)
  let fb = F(b)
  if \{$fa * $fb > 0\} \\
   \{after 0 \{error \"Sign of f(a) and f(b) must be different\"\}\}
  let (mx,Mx,nx) = D
  set NeedsReset 1
\}

Axes \{x y\}}
  {selected 1 each}
  {{set y} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Root-Bisection/Axis {
  {#
#  This is just a straight line.  Its
#  z-coordinate is set to make it fall
#  behind the other items being displayed.
#

Vertices \{
 lx: (mx,0,-.05)  rx: (Mx,0,-.05)
\}

Faces \{
 \{lx rx\} <- \{color \{0 0 0\} width 1\}
\}}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Root-Bisection/Curve {
  {#
#  This is the graph of y=f(x).  Its
#  z-coordinate is set so that it falls
#  above the axis, but behind the other
#  displayed items

Domain \{mx Mx nx\}

Function \{x\} \{let y = ($f)\}

Axes \{x y z\}
Setup \{let z = -.025\}}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Polyhedron Create Root-Bisection/Solution {
  {#
#  Here we show the current and past values
#  for the bisection interval.
#

Vertices \{
 x0: (x0,0)  f0: (x0,f0)
 x1: (x1,0)  f1: (x1,f1)
\}

#
#  We use a line for each end of the interval
#  and a point at at the base of each.
#
#  The \"history\" variable keeps track of
#  old positions as the evolution
#  progresses.
#
Faces \{
 \{\{x0 f0\} \{x1 f1\}\} <- \{color \{0 1 0\}\}
 x0 <- \{color \{0 1 0\} width 4\}
 x1 <- \{color \{0 1 0\} width 4\}
 \{$history\} <- \{color \{.25 .5 .25\}\}
\}

#
#  Reseting means go back to the initial
#  values of a and b, and clear the history
#
proc Reset \{\} \{
  uplevel \{
    let x0 = a; let f0 = F(x0)
    let x1 = b; let f1 = F(x1)
    set history \{\}
    set c \"\"; set fc \"\"
    set n 0
  \}
\}

#
#  At each step of the bisection method
#  we find the midpoint (c) of the current
#  interval, and compute the function's value
#  there.  If the sign differs at the left
#  endpoint, replace the right-hand endpoint
#  by c, otherwise replace the left endpoint.
#  Add the old endpoint to the history.
#  If the current function value is close
#  enough to zero, then stop the evolver
#  Return the current x-position and its
#  function value for display by the evolver.
#
proc Step \{\} \{
  uplevel \{
    let c = (x0 + x1) / 2
    let fc = F(c)
    if \{$fc * $f0 < 0\} \{
      let edge = ((x1,0,0), (x1,f1,0))
      let point = (x1,0,0)
      let (x1,f1) = (c,fc)
    \} else \{
      let edge = ((x0,0,0), (x0,f0,0))
      let point = (x0,0,0)
      let (x0,f0) = (c,fc)
    \}
    lappend history $edge
    lappend history [list [list $point]] <- \{width 4\}
    if \{abs($fc) < $e\} \{Self Evolver n Stop\}
    incr n
  \}
\}

#
#  The evolver itself
#
Evolve n Step() -reset Reset() -title \"Steps:\" \\
  -in controls -at \{1 1\} -steptime 1

#
#  The results
#
set c \"\"; set fc \"\"
TypeOut c -title \"c =\" -in output -at \{0 0\} -titlewidth 6
TypeOut fc -title \"f(c) =\" -in output -at \{0 1\} -titlewidth 6

#
#  Make sure everything is reset initially
#
Reset

#
#  If the parent group has had a variable
#  change, NeedsReset will be true, so 
#  we set the value of the evolver and
#  reset the current state.
#
Setup \{
  if \{$NeedsReset\} \{
    Self Evolver n Reset
    set NeedsReset 0
  \}
\}}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Root-RegulaFalsi {
  {#
#  Implements the Regula Falsi method of root
#  finding.  You get to specify the function
#  and the starting positions for the
#  search (a and b).  These must be such
#  that f(a) and f(b) have opposite signs.
#

Window controls -rows \{1 1\} -columns \{1 1\} \\
  -title \"Regula Falsi\"
Frame inputs -in controls -at \{0 0 1 2\} \\
  -rows \{1 1 1 1\} -columns 1 -relief raised -bd 2
Frame output -in controls -at \{1 0\} -bg grey70 \\
  -rows \{1 1\} -columns 1 -relief raised -bd 2

TypeIn f \"x^3-3x+1\" -title \"f(x) =\" -in inputs -at \{0 0\} -titlewidth 8
TypeIn D \"(-2,2,100)\" -title \"Domain:\" -evaluate -in inputs -at \{0 1\} -titlewidth 8
Frame ab -in inputs -at \{0 2\} -rows 1 -columns \{1 1\}
TypeIn a \"-1.75\" -evaluate -width 6 -in ab -at \{0 0\}
TypeIn b \"1.3\" -evaluate -width 6 -in ab -at \{1 0\}
TypeIn e \".005\" -evaluate -title \"Max error:\" -in inputs -at \{0 3\}

#
#  The function's value at x
#
proc F \{x\} \{
  variable f
  let y = ($f)
  return $y
\}

#
#  This is used to tell the evolver
#  that the setup has changed and the
#  process needs to be reset
#
set NeedsReset 0

#
#  Get the initial values of f at a and b
#  And check that they are of opposite
#  signs (the error is done using \"after\" 
#  so that the function will be displayed
#  anyway -- this makes it easier to choose
#  appropriate values for a and b).
#
#  We also get the values of the domain
#  and indicate to the Evolver that it
#  will need to be reset.
#
Setup \{
  let fa = F(a)
  let fb = F(b)
  if \{$fa * $fb > 0\} \{
    after 0 \\
    \{error \"Sign of f(a) and f(b) must be different\"\}
  \}
  let (mx,Mx,nx) = D
  set NeedsReset 1
\}

Axes \{x y\}}
  {selected 1 each}
  {{set y} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Root-RegulaFalsi/Axis {
  {#
#  This is just a straight line.  Its
#  z-coordinate is set to make it fall
#  behind the other items being displayed.
#

Vertices \{
 lx: (mx,0,-.05)  rx: (Mx,0,-.05)
\}

Faces \{
 \{lx rx\} <- \{color \{0 0 0\} width 1\}
\}}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Root-RegulaFalsi/Curve {
  {#
#  This is the graph of y=f(x).  Its
#  z-coordinate is set so that it falls
#  above the axis, but behind the other
#  displayed items

Domain \{mx Mx nx\}

Function \{x\} \{let y = ($f)\}

Axes \{x y z\}
Setup \{let z = -.025\}}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Polyhedron Create Root-RegulaFalsi/Solution {
  {#
#  Here we show the current and past values
#  for the endpoints of the interval, and
#  the position of the next estimated
#  zero location.
#

Vertices \{
 x0: (x0,0)  f0: (x0,f0)
 x1: (x1,0)  f1: (x1,f1)
 c: (c,0)
\}

#
#  We use a line for each end of the interval
#  and a point at at the base of each.
#
#  We also show the linear approximate to
#  the function based on the two endpoints,
#  and the estimated location of the zero
#  based on this approximation.
#
#  The \"history\" variable keeps track of
#  old positions as the evolution
#  progresses.
#
Faces \{
 \{\{x0 f0\} \{x1 f1\}\} <- \{color \{0 1 0\}\}
 \{\{f0 f1\}\} <- \{color \{1 1 0\}\}
 c <- \{color \{1 1 0\} width 4\}
 x0 <- \{color \{0 1 0\} width 4\}
 x1 <- \{color \{0 1 0\} width 4\}
 \{$history\} <- \{color \{.25 .5 .25\}\}
\}

#
#  Reseting means go back to the initial
#  values of a and b, and clear the history
#
proc Reset \{\} \{
  uplevel \{
    let x0 = a; let f0 = F(x0)
    let x1 = b; let f1 = F(x1)
    let c = (x0 f1 - x1 f0) / (f1 - f0)
    let fc = F(c)
    set history \{\}
    set n 0
  \}
\}

#
#  At each step of the bisection method
#  we find the next estimate of the location
#  of the functions zero, and compute the 
#  function's actual value there.  If the
#  sign differs at the left endpoint,
#  replace the right-hand endpoint by c,
#  otherwise replace the left endpoint.
#  Add the old endpoint to the history.
#  If the current function value is close
#  enough to zero, then stop the evolver
#  Return the current x-position and its
#  function value for display by the evolver.
#
proc Step \{\} \{
  uplevel \{
    if \{$fc * $f0 < 0\} \{
      let edge = ((x1,0,0), (x1,f1,0))
      let point = (x1,0,0)
      let (x1,f1) = (c,fc)
    \} else \{
      let edge = ((x0,0,0), (x0,f0,0))
      let point = (x0,0,0)
      let (x0,f0) = (c,fc)
    \}
    let c = (x0 f1 - x1 f0) / (f1 - f0)
    let fc = F(c)
    lappend history $edge
    lappend history [list [list $point]] <- \{width 4\}
    if \{abs($fc) < $e\} \{Self Evolver n Stop\}
    incr n
  \}
\}

#
#  The evolver itself
#
Evolve n Step() -reset Reset() -title \"Steps:\" \\
  -in controls -at \{1 1\} -steptime 1

#
#  The results
#
set c \"\"; set fc \"\"
TypeOut c -title \"c =\" -in output -at \{0 0\} -titlewidth 6
TypeOut fc -title \"f(c) =\" -in output -at \{0 1\} -titlewidth 6

#
#  Make sure everything is reset initially
#
Reset

#
#  If the parent group has had a variable
#  change, NeedsReset will be true, so 
#  we set the value of the evolver and
#  reset the current state.
#
Setup \{
  if \{$NeedsReset\} \{
    Self Evolver n Reset
    set NeedsReset 0
  \}
\}}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create TaylorSeries {
  {#
#  A Taylor Series with variable number
#  of terms (computes formula for it as
#  a string for use with \"let\")
#
#  Be sure to turn on the checbox before
#  starting the animation
#

Axes \{x y\}

Window controls -title \"Taylor Series\"}
  {selected 1 each}
  {{set y} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create TaylorSeries/Axes {
  {Length \{14 10\}
ArrowHead 1.5 .3 -outline -absolute

# \"Axes\" directive is inherited from group}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create TaylorSeries/BBox {
  {#
#  This is mostly to cover over the
#  part of the Taylor series graph that
#  is \"clipped\"
#

Faces \{
 \{\{\{-14 -10 .02\} \{14 -10 .02\}
  \{14 10 .02\} \{-14 10 .02\}\}\} <- outline
\}

Axes \{x y z\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Curve Create TaylorSeries/Curve {
  {Domain \{-14 14 75\}

Function \{x\} \{
  let y = sin(x)
\}
}
  {always 1 each}
  {{ list 1 0 0} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Curve Create TaylorSeries/Series {
  {Domain \{-14 14 75\}

#
#  \"Clip\" the taylor series graph so that
#  its doesn't cause Geomview to resize it
#  very small
#
Function \{x\} \{
  let y = $f
  let y = Max(Min(y,10),-10); # clip to BBox
\}

#
#  Here we write out the formula for
#  the taylor series (symbolically) as
#  a string.  This is then evaluated
#  in the function above (saving the
#  overhead of doing the loop).
#  We use Horner's method to compute
#  the series efficiently.
#

Setup \{
  set i $n; set f \"x\"
  while \{[incr i -1] > 0\} \{
    let p = (2i)(2i+1)
    set f \"(x-(x*x/$p)$f)\"
  \}
  set z .01; # put this one on top
\}

Slider n 0 20 -resolution 1 -in controls -at \{0 1\} \\
  -title \"Number of terms\" -width 200

Animate nn 9 \{Slider n 1 19\} -in controls -at \{0 2\} \\
  -title \"Animate series - Step\" -loop -bounce \\
  -steptime 1

ShowMe \{n != 0\}

Axes \{x y z\}}
  {always 1 each}
  {{ list 0 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create TaylorSeries-1 {
  {#
#  A Taylor Series with variable number
#  of terms (computes value using a
#  loop).
#

Axes \{x y\}

Window controls -title \"Taylor Series\"}
  {selected 1 each}
  {{set y} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create TaylorSeries-1/Axes {
  {Length \{14 10\}
ArrowHead 1.5 .3 -outline -absolute

# \"Axes\" directive is inherited from group}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create TaylorSeries-1/BBox {
  {#
#  This is mostly to cover over the
#  part of the Taylor series graph that
#  is \"clipped\"
#

Faces \{
 \{\{\{-14 -10 .02\} \{14 -10 .02\}
  \{14 10 .02\} \{-14 10 .02\}\}\} <- outline
\}

Axes \{x y z\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Curve Create TaylorSeries-1/Curve {
  {Domain \{-14 14 75\}

Function \{x\} \{
  let y = sin(x)
\}
}
  {always 1 each}
  {{ list 1 0 0} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Curve Create TaylorSeries-1/Series {
  {Domain \{-14 14 75\}

#
#  Here we compute the taylor series in
#  a loop (for each of the points on
#  the curve).  This works, but is not as
#  efficient as the previous method.
#
Function \{x\} \{
  set i $n; set y $x
  while \{[incr i -1] > 0\} \{
    let y = x - (x^2 y)/(2i(2i+1))
  \}
  let y = Max(Min(y,10),-10); # clip to BBox
  set z .01; # put this one on top
\}

Slider n 0 20 -resolution 1 -in controls -at \{0 1\} \\
  -title \"Number of terms\" -width 200

Animate nn 9 \{Slider n 1 19\} -in controls -at \{0 2\} \\
  -title \"Animate terms - Step:\" -loop -bounce \\
  -steptime 1

ShowMe \{n != 0\}

Axes \{x y z\}}
  {always 1 each}
  {{ list 0 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Surface Create ToOOGL {
  {#
#  This example lets you produce a sequence of
#  OOGL files that correspond to changes in a
#  parameter of a surface.  Thse can be read 
#  directly into Geomview without the need
#  for CenterStage to recompute them.  For
#  example, you can use Geomview's Animator
#  module to animate the sequence without
#  recomputation.
#
#  You can test the parameter change by sliding
#  the slider, or by running the animation (using
#  the START button.
#
#  Once you are ready to make the OOGL files,
#  press the MAKE OOGL FILES button.  (You can
#  interrupt the process by pressing STOP.)
#
#  The files will be stored in the directory
#  named below within the directory where this
#  file is stored.  The number of files is given
#  be \"steps\"; it should be even so that the
#  midpoint of the movie shows the symmetric
#  position with the torus spread out to infinity.
#

let steps = 10
set directory \"OOGL\"

Domain \{\{-1.2 1.2 15\} \{-1 1 12\}\}
Function \{x y\} \{
  let z = x^3 + a x - y^2
\}


#
#  The control panel and widgets.
#
Window controls -rows \{1 1 1\} -columns 1
Frame mbox -rows 1 -columns \{1 1\} -bg grey75 \\
  -in controls -at \{0 2\}

Slider a 0 -1 -width 200 -in controls -at \{0 0\}

Animate n steps \{Slider a\} -title \"Step\" \\
  -in controls -at \{0 1\}

Button movie -title \"Make OOGL files\" \\
  -command Movie -in mbox -at \{0 0\}
Button stop -title \"Stop\" -disabled \\
  -command \{set running 0\} \\
  -in mbox -at \{1 0\}

#############################################
#
#  These routines are for making the movie.
#  You shouldn't change what's below this.
#

set dir \"\";    # the full directory path
set running 0; # are we making a movie?


#
#  Create and clear the directory, if needed.
#  Grab the movie-button frame so that no other
#    widgets will be active while the movie runs.
#  Enable the STOP button
#  Mark the fact that we are making a movie
#  Capture any errors in the movie loop (so we
#    can clean up afterward)
#  For each step in the movie
#    Set the animator to the proper value (it will
#      cause the slider to update and the object to
#      recompute itself).
#    See if the STOP button has been pressed
#    Capture the current state of the object
#  We're done with the movie
#  Disable the STOP button
#  Reactivate the other widgets
#  Return whatever code and message the loop
#    produced
#
proc Movie \{\} \{
  variables steps directory running
  SetupDirectory $directory
  set frame [Self Frame mbox WidgetName]; grab $frame
  Self Button stop Enable
  set running 1
  set code [catch \{
    for \{set i 0\} \{$i <= $steps\} \{incr i\} \{
      Self Animator n Set $i
      update; if \{!$running\} \{Error \"Movie cancelled\"\}
      Snapshot $i
    \}
  \} error]
  set running 0
  Self Button stop Disable
  grab release $frame
  return -code $code $error
\}


#
#  Get the full directory path name
#  Check if it already exists
#    If so, then check if it is a directory
#      If it is, clear out all its files
#    Otherwise report that it isn't a directory
#  Otherwise create the directory
#
proc SetupDirectory \{directory\} \{
  variable dir
  set dir [file join [::cs::File get pwd] $directory]
  if \{[file exists $dir]\} \{
    if \{[file isdirectory $dir]\} \{
      foreach file [glob -nocomplain -- [file join $dir \"*\"]] \\
        \{file delete $file\}
    \} else \{Error \"'$dir' is not a directory\"\}
  \} else \{file mkdir $dir\}
\}


#
#  Get the file name for the OOGL file
#  Ask the object to write out its OOGL data
#
proc Snapshot \{i\} \{
  variable dir
  set oogl [file join $dir CS[format %03d $i].oogl]
  Self _SaveOOGL $oogl
\}
}
  {selected 1 keep}
  {{set z} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}
