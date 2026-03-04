#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Calculus-Part3.cs
#  Created:  Fri Nov 19 17:21:46 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Calculus-9 {
  {#
#  This example lets you investigate the connection
#  between the gradient vector field, the level
#  sets, and the critical points of a function.
#
#  The slider controls the height of a slicing
#  plane.  You can add the gradients of the
#  function to this plane and see how they always
#  intersect the level curve perpendicularly.
#  (This is particularly visible when the surface
#  is turned off).
#
#  You can locate the critical points visually
#  (finding the places where the slicing plane is
#  tangent to the surface), and zoom in on the
#  gradient field at these points (using Geomview's
#  scaling controls).  Note the different in
#  the gradients for the saddle versus the maximum.
#

#
#  The window and frames for the controls.
#
Window controls -rows \{1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -rows \{1 1 1\} -columns 1 -relief raised -bd 2
Frame cbox -in fbox -at \{0 2\} -bd 2 \\
  -rows 1 -columns \{1 1 1 1 1\}

#
#  The function and its domain.
#
TypeIn f \"x^3 - x - y^2\" -title \"z = f(x,y) =\" \\
  -titlewidth 11 -in fbox -at \{0 0\} -width 30
TypeIn XY \"\{-1.25 1.5 12\} \{-1.25 1.25 10\}\" \\
  -title \"Domain:\" -evaluate -titlewidth 11 \\
  -in fbox -at \{0 1\}

#
#  Break up the domain into its components.
#
Setup \{let ((xm,xM,xn),(ym,yM,yn)) = XY\}

#
#  A procedure to evaluate f at (x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 1 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-9/Proto {
  {#
#  These objects are never displayed.  They are
#  used as \"caches\" so that they only need to be
#  computed once rather than every timne some
#  checkbox or slider updates.  The linked objects
#  will read the data from them rather than
#  recompute it each time it is needed.
#}
  {hide 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::GradientField Create Calculus-9/Proto/Gradients {
  {#
#  This is the gradient vector field.
#

Domain \{\{xm xM xn\} \{ym yM yn\}\}

#
#  These parameters try to make the arrows
#  more attractive.  See the Arrows class
#  documentation for more details
#
ArrowScale .15
ArrowHead .4 .12 .2 .05 -solid -relative
ArrowMaxLen clip -keep

#
#  Since we really only care about the direction
#  of the vectors here, we can clip them to 
#  a shorter length.
#
Setup \{
  if \{$short\} \{set clip .2\} else \{set clip 0\}
\}

CheckBox short 1 -title \"Short\" -in cbox -at \{3 0\}}
  {hide 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {0 1}
}

####################

::class::Polyhedron Create Calculus-9/Proto/Plane {
  {#
#  This is a horizontal plane.  It wil be raised
#  to the right hight by the actual object
#  that displays it.
#

Vertices \{
 00: (xm,ym,0)  01: (xm,yM,0)
 10: (xM,ym,0)  11: (xM,yM,0)
\}

Faces \{
  \{00 01 11 10\}
\}}
  {hide 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {2 {}}
}

####################

::class::Surface Create Calculus-9/Proto/Surface {
  {#
#  This is a standard surface graph with
#  a black border.  Technically, we should
#  do th eborder in a separate object since
#  we don't need the level set to slice the
#  boundaries, but that isn't all that expensive
#  so we let it go.
#

Domain \{
  \{\{xm xM xn\} \{ym yM yn\}\}
  \{\{xm xM xn\} \{ym yM 1\}  LinesU \{0 0 0\}\}
  \{\{xm xM 1\}  \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}
}
  {hide 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {1 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-9/Slice {
  {#
#  This group displays the level set and gradients
#  at the proper height.
#

Slider k -3 3 0 -in controls -at \{0 1\} \\
  -title \"Show plane at height k =\"
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create Calculus-9/Slice/Gradients {
  {#
#  We translate the prototype gradients up
#  to the correct height.
#

Transform \{Translate(0,0,k)\}

CheckBox Gradients 0 -in cbox -at \{2 0\}
ShowMe Gradients
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Calculus-9/Slice/Level {
  {#
#  We slice the prototype surface graph at the
#  correcet height.
#

Height z = k

CheckBox show 1 -title \"Level Curve\" \\
  -in cbox -at \{4 0\}
ShowMe show}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 1}
}

####################

::class::DataFromPolyhedron Create Calculus-9/Slice/Plane {
  {#
#  We translate the prototype plane to the
#  correct height.
#

Transform \{Translate(0,0,k)\}
}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 2}
}

####################

::class::DataFromSurface Create Calculus-9/Surface {
  {#
#  This displays the prototype surface (so we
#  don't need to recompute it, and more importantly
#  the gradient field) every time we change the
#  checkbox below.
#

CheckBox Surface 1 -in cbox -at \{1 0\}
ShowMe Surface
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-10 {
  {#
#  This example shows how the composition of a
#  parametric curve in the plane with a function
#  of two variables can be considered as a
#  single-variable function.  When finding the
#  extrema of a function f:R^2 -> R over a bounded
#  region of the plane, one way is to find the
#  critical points within the region and then
#  find the extrema along the boundary.  This
#  demonstration shows how the latter can be
#  handled as a single-variable problem.
#

#
#  The window and frames for the widgets.
#
Window controls -rows \{1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows \{1 1 1 1 1\} -columns 1
Frame cbox -in fbox -at \{0 4\} -bd 2 \\
  -columns \{1 1 1 1 1\}

#
#  The function and its domain.
#
TypeIn f \".75 (x - .2) (y - .5) + 2\" -width 30 \\
  -title \"f(x,y) =\" -titlewidth 12 \\
  -in fbox -at \{0 0\}
TypeIn XY \"\{-2 2 15\} \{-2 2 15\}\" \\
  -title \"Domain of f:\" -evaluate \\
  -titlewidth 12 -in fbox -at \{0 1\}

#
#  The parameterized boundary curve and its
#  domain.
#
TypeIn g \"1.75 (cos t, sin t)\" -title \"g(t) =\" \\
  -titlewidth 12 -in fbox -at \{0 2\}
TypeIn T \"\{0 2pi 32\}\" -title \"Domain of g:\" \\
  -evaluate -titlewidth 12 -in fbox -at \{0 3\}

#
#  Break the domains into their components.
#
Setup \{
  let ((xm,xM,xn),(ym,yM,yn)) = XY
  let (tm,tM,tn) = T
\}

#
#  A procedure for evaluating f at (x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}

#
#  A procedure for evaluating g at t.
#
vproc G \{t\} \{
  variable g
  let X = ($g)
  return $X
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-10/Animation {
  {#
#  The group displays the curve and the composition
#  and provides an animation that shows the
#  curve \"unwrapping\" into a plannar graph.
#
#  The unwrapping uses a straight linear
#  interpolation between the point g(t) on the 
#  curve and the point (t,0) on the x-axis, so
#  the unwrapping can undergo unusual pinchings
#  and the like.  Fortunately, for the circular
#  example given here, this does not occur.
#

set u 0
Animate step 15 \{u 0 1\} -in controls -at \{0 1\} \\
  -title \"Unwrap curve:  Step\" -bg grey75}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Calculus-10/Animation/Composition {
  {#
#  This object shows the image of the g(t) curve
#  on the surface graph, together with some
#  vertical stripes that show how the curve
#  is \"lifted up\" to its image.
#

Domain \{
  \{\{tm tM int(tn/2)\} \{0 1 1\} StripesV\}
  \{\{tm tM tn\} \{1 1 1\} LinesU \{1 1 0\}\}
\}

#
#  We compute the relative position tt between
#  the max and min values of t, and use that
#  to compute the positions X and Y for the
#  animation.  X is the point on the curve itself
#  and Y is the point along the x-axis in a
#  planar graph of the unwrapped curve and 
#  composition.  Then we use the animation
#  parameter to interpolate a position along
#  the line between these two points.
#  
Function \{t v\} \{
  let tt = (t - tm) / (tM - tm)
  let Y = (0, tt ym + (1-tt) yM)
  let X = G(t)
  let (x,y) = u Y + (1-u) X
  if \{$v > 0\} \{let z = F(X)\} else \{set z .01\}
\}

CheckBox show 0 -title \"(f o g)(t)\" -in cbox -at \{4 0\}
ShowMe show}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::sd::Grid 0 0 0.2}
}

####################

::class::Curve Create Calculus-10/Animation/Path {
  {#
#  This is the image of g(t) in the xy-plane.
#

Domain \{tm tM tn\}

#
#  We compute the relative position tt between
#  the max and min values of t, and use that
#  to compute the positions X and Y for the
#  animation.  X is the point on the curve itself
#  and Y is the point along the x-axis in a
#  planar graph of the unwrapped curve and 
#  composition.  Then we use the animation
#  parameter to interpolate a position along
#  the line between these two points.
#  
Function \{t\} \{
  let tt = (t - tm) / (tM - tm)
  let Y = (0, tt ym + (1-tt) yM)
  let (x,y) = u Y + (1-u) G(t)
  set z .01
\}

CheckBox show 0 -title \"g(t)\" -in cbox -at \{3 0\}
ShowMe show}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Calculus-10/Surface {
  {#
#  This shows the surface grap together with
#  the xy-plane and the function's domain.
#

CheckBox show 1 -title \"Surface\" -in cbox -at \{1 0\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Calculus-10/Surface/Domain {
  {#
#  The corners of the domain and their images
#  on the graph.
#

Vertices \{
 000: (xm,ym,0)   001: (xm,ym,F(xm,ym))
 010: (xM,ym,0)   011: (xM,ym,F(xM,ym))
 100: (xm,yM,0)   101: (xm,yM,F(xm,yM))
 110: (xM,yM,0)   111: (xM,yM,F(xM,yM))
\}

#
#  We calculate the faces below.
#
Faces \{$faces\}

#
#  Here we create the list of faces depending
#  on the values of various checkboxes.
#
Setup \{
 set faces \{
   \{000 010 110 100\} <- \{outline color \{0 0 0\}\}
 \}

 if \{$show\} \{
   append faces \{
     \{\{000 001\}
      \{010 011\}
      \{100 101\}
      \{110 111\}\} <- \{color \{0 0 0\}\}
   \}
 \}

 if \{$xyPlane\} \{lappend faces \{000 100 110 010\}\}
\}

CheckBox xyPlane 0 -title \"xy-plane\" \\
  -in cbox -at \{2 0\}}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-10/Surface/Surface {
  {#
#  This is the standard surface graph with 
#  a black border.
#

Domain \{
  \{\{xm xM xn\} \{ym yM yn\}\}
  \{\{xm xM xn\} \{ym yM 1\}  LinesU \{0 0 0\}\}
  \{\{xm xM 1\}  \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}

ShowMe show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-11 {
  {#
#  This example motivates  the idea of Lagrange
#  multipliers.  In it, the student can define 
#  a function of two variables, and a region in
#  the plane as the area inside a curve defined
#  implicitly by another function.  The idea is
#  to locate the extreme value of the composition
#  of this curve with the original function.
#
#  The student can investigate the relationship
#  between the composition and the level sets
#  of the graph.  At the extreme values, the
#  level sets will be tangent to the composition,
#  and so the gradient vectors will be perpendicular
#  to the curve defined implicitly by g.  That is,
#  the gradients of f and g will be parallel.
#
#  In the end, the student can compare the
#  gradient vector field for the function to the
#  implicit curve and locate the potential
#  candidates for extreme values visually.
#

#
#  The window and frames for the widgets.
#
Window controls -rows \{1 1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows \{1 1 1 1 1 1\} \\
  -columns \{3 1\}
Frame cbox -in fbox -at \{0 3 2 1\} -bd 2 \\
  -columns \{1 1 1\}
Frame gbox -in controls -at \{0 1\} \\
  -relief raised -bd 2 -columns \{1 1 1 1\} \\
  -rows \{\{0 2\} 1 \{0 2\} \{0 2\} 1 1 \{0 2\}\}

#
#  The function and its domain.
#
TypeIn f \".75 (x - .2) (y - .5) + 2\" -title \"f(x,y) =\" \\
  -width 30 -titlewidth 8 -in fbox -at \{0 0 2 1\}
TypeIn XY \"\{-2 2 15\} \{-2 2 15\}\" \\
  -title \"Domain:\" -evaluate \\
  -titlewidth 8 -in fbox -at \{0 1 2 1\}

#
#  Extract the components of the domain.
#
Setup \{let ((xm,xM,xn),(ym,yM,yn)) = XY\}

#
#  A procedure for evaluating f at (x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-11/f-slice {
  {#
#  This group collects the objects related
#  to the level sets of f.
#

#
#  The heeight at which the slice occurs.
#
Slider h 0 4 1 -title \"Slice height:\" \\
  -in controls -at \{0 2\} -bg grey75 -disabled

#
#  Some extra colored boxes to make the 
#  f-slice portion of the panel colored darker.
#
Frame color0 -in gbox -at \{0 3 4 1\} -bg grey75
Frame color1 -in gbox -at \{0 4 1 2\} -bg grey75
Frame color2 -in gbox -at \{0 6 4 1\} -bg grey75

#
#  This checkbox activates the other ones.
# 
CheckBox show 0 -title \"f-slice:\"  -bg grey75 \\
  -in gbox -at \{1 4 1 2\} -command EnableDisable
ShowMe show

#
#  We determine whether the checkboxes need to be
#  enabled or disabled, and then run through
#  the list of child objects and set their
#  checkboxes accordingly.  Note that the name
#  of the checkbox is also the name of the object
#  in each case.
#
proc EnableDisable \{\} \{
  variable show
  set action [lindex \{Disable Enable\} $show]
  foreach child \{Level Plane Projection Gradients\} \\
    \{Child $child CheckBox $child $action\}
  Self Slider h $action
  Update
\}}
  {always 1 each}
  {{ list 0 0 1} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Vectors Create Calculus-11/f-slice/Gradients {
  {#
#  This generates the gradients for the level
#  curve associated with this slice.  We place
#  a gradient vector at the center of each edge
#  that is part of the level curve.
#

CheckBox Gradients 0 \\
  -in gbox -at \{3 5\} -bg grey75 -disabled
ShowMe Gradients

#
#  The vectors are constructed below.
#
Vectors \{[MakeVectors]\} 

#
#  First we get the segments that are part of the
#  level set (a sibling object to this one).
#  For each face
#    We get the points for the face (the first
#      element in the data for the face).
#   If it is an edge (we ignore anything else)
#     Get the endpoints.
#     Compute the center of the edge.
#     Get the gradient of the surface at that point.
#       (We are linked to the surface object,
#        so can use the Object procedure to get it.)
#     We create a vector at the center in
#       the direction of the gradient (appropriately
#       normalized and scaled)
#     and add that to the list of vectors.
#  We return the list of vectors created.
#    
proc MakeVectors \{\} \{
  variable d
  set V \{\}
  foreach face [Sibling Level GetFaces] \{
    set face [lindex $face 0]
    if \{[llength $face] == 2\} \{
      let (p0,p1) = face
      let (x,y,z) = (p0 + p1) / 2
      set Df [Object Gradient $x $y]
      let v = ((x,y,0), d Unit(Df)::0)
      lappend V $v
    \}
  \}
  return $V
\}

#
#  We compute a normalization factor in relation
#  to the size of the domain of f.
#
set d .3
Setup \{let d = Max(xM-xm,yM-ym) / 8\}

ArrowHead .3 .075 -relative}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
}

####################

::class::Levels Create Calculus-11/f-slice/Level {
  {#
#  This is the level set for the function f
#  at the specified height.
#

Height z = h

CheckBox Level 1 \\
  -in gbox -at \{2 5\} -bg grey75  -disabled
ShowMe Level}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {3 5}
}

####################

::class::Polyhedron Create Calculus-11/f-slice/Plane {
  {#
#  This is a rectangle parallel to the xy-plane
#  at the specified height.
#

Faces \{
  \{(xm,ym,h) (xm,yM,h) (xM,yM,h) (xM,ym,h)\}
\}

CheckBox Plane 1 \\
  -in gbox -at \{2 4\} -bg grey75 -disabled
ShowMe Plane}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create Calculus-11/f-slice/Projection {
  {#
#  Here we project the level set down to the
#  xy-plane for display there.
#

Transform \{Project x y\}

CheckBox Projection 0 \\
  -in gbox -at \{3 4\} -bg grey75 -disabled
ShowMe Projection}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 3}
}

####################

::class::Group Create Calculus-11/g-curve {
  {#
#  This group collects all the objects
#  needed to display the implicit curve
#  and its related items.
#

#
#  The function for the implicit curve and
#  the value that yields the curve.
#
TypeIn g \"x^2 + y^2\" -title \"g(x,y) =\" \\
  -titlewidth 8 -in fbox -at \{0 2\}
TypeIn k \"3\" -title \"= \" -width 5 -evaluate \\
  -in fbox -at \{1 2\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-11/g-curve/Actual {
  {#
#  We use prototype objects so that we can turn
#  them off and on without recomputing.  These
#  are the actual visible ones.
#

#
#  This checkbox activates the other ones.
#
CheckBox show 0 -title \"g-curve:\" \\
  -in gbox -at \{1 1\} -command EnableDisable
ShowMe show

#
#  The usual method of making checkboxes
#  active or not.
#
proc EnableDisable \{\} \{
  variable show
  set action [lindex \{Disable Enable\} $show]
  foreach child \{Composition Gradients\} \\
    \{Child $child CheckBox $child $action\}
  Update
\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create Calculus-11/g-curve/Actual/Composition {
  {#
#  Here we take the edges that are part of the
#  implicit curve and map them through the
#  function f so that they are on the surface
#  in space.  To do so, we link to the implicit
#  curve and use a vApply transform to modify
#  the vertices of each edge.
#

#
#  We decompose each vertex into its components
#  and apply the function F to form a point
#  on the graph of f.
#

proc mapF \{v\} \{
  let (x,y,z) = v
  let v = (x,y,F(x,y))
\}

Transform \{vApply mapF\}

CheckBox Composition 0 -in gbox -at \{2 1\} -disabled
ShowMe Composition
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 6}
}

####################

::class::DataFromPolyhedron Create Calculus-11/g-curve/Actual/Curve {
  {#
#  This is a copy of the data from the prototype
#  version of the implicit curve.
#}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {6 7}
}

####################

::class::Vectors Create Calculus-11/g-curve/Actual/Gradients {
  {#
#  This shows gradient vectors along the implicit
#  curve.
#
CheckBox Gradients 0 -in gbox -at \{3 1\} -disabled
ShowMe Gradients

#
#  The vectors are computed below.
#
Vectors \{[MakeVectors]\} 

#
#  See the f-slice/Gradients object for a 
#  detailed description of this function.
#
proc MakeVectors \{\} \{
  variable d
  set V \{\}
  foreach face [Sibling Curve GetFaces] \{
    set face [lindex $face 0]
    if \{[llength $face] == 2\} \{
      let (p0,p1) = face
      let (x,y,z) = (p0 + p1) / 2
      set Df [Object Gradient $x $y]
      let v = ((x,y,0),d Unit(Df)::0)
      lappend V $v
    \}
  \}
  return $V
\}

#
#  The gradients are normalized based on the
#  size of the domain.
#
set d .3
Setup \{let d = Max(xM-xm,yM-ym) / 8\}

ArrowHead .3 .075 -relative}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 8}
}

####################

::class::Group Create Calculus-11/g-curve/Proto {
  {#
#  These objects will only be computed once, and
#  can be used quickly by other objects that
#  need their data.
#}
  {hide 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Calculus-11/g-curve/Proto/Curve {
  {#
#  This is the implicit curve in the plane.
#  It is computed by slicing the graph of g
#  at the given height and projecting it
#  into the xy-plane.
#

Height z = k

Transform \{Project x y\}}
  {hide 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {7 8}
}

####################

::class::Surface Create Calculus-11/g-curve/Proto/Graph {
  {#
#  This is the graph of g over the domain.
#  It is never shown, but is used by several
#  other objects.
#

Domain \{$XY\}

Function \{x y\} \{let z = ($g)\}
}
  {hide 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {8 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::GradientField Create Calculus-11/GradientField {
  {#
#  This is the gradient vector field for the
#  graph if f.
#

Domain Inherit

ArrowScale .5
ArrowMaxLen .25 -keep
ArrowHead .3 .1 -relative -outline

CheckBox show 0 -title \"Gradient field for f(x,y)\" \\
  -in cbox -at \{3 0\}
ShowMe show}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
}

####################

::class::Group Create Calculus-11/Proto {
  {#
#  These are prototype objects related to f
#  that get computed only once, and then
#  are used quickly by other objects.
#}
  {hide 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Calculus-11/Proto/Boundary {
  {#
#  These are the black borders for the
#  surface graph.  (We make a prototype
#  from them so that we can turn on and off
#  the surface without recomputing them).
#
Domain \{
  \{\{xm xM xn\} \{ym yM 1\}  LinesU \{0 0 0\}\}
  \{\{xm xM 1\}  \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {4 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Calculus-11/Proto/Surface {
  {#
#  The graph of f.
#
Domain \{\{xm xM xn\} \{ym yM yn\}\}

Function \{x y\} \{let z = ($f)\}
}
  {hide 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {5 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-11/Surface {
  {#
#  This is the copy of the surface and its
#  domain that is actually shown.
#

CheckBox show 1 -title \"Surface\" -in cbox -at \{1 0\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromSurface Create Calculus-11/Surface/Boundary {
  {#
#  The boundary of the surface
#

ShowMe show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 4}
  {::sd::Patch 0 0 .25}
}

####################

::class::Polyhedron Create Calculus-11/Surface/Domain {
  {#
#  The corners of the domain and their images
#  on the graph of the surface.
#

Vertices \{
 000: (xm,ym,-0.01)   001: (xm,ym,F(xm,ym))
 010: (xM,ym,-0.01)   011: (xM,ym,F(xM,ym))
 100: (xm,yM,-0.01)   101: (xm,yM,F(xm,yM))
 110: (xM,yM,-0.01)   111: (xM,yM,F(xM,yM))
\}

#
#  The faces are set up below.
#
Faces \{$faces\}

#
#  We create the faces according to the state
#  of several checkboxes.
#
Setup \{
 set faces \{
   \{000 010 110 100\} <- \{outline color \{0 0 0\}\}
 \}

 if \{$show\} \{
   append faces \{
     \{\{000 001\}
      \{010 011\}
      \{100 101\}
      \{110 111\}\} <- \{color \{0 0 0\} width 2\}
   \}
 \}

 if \{$xyPlane\} \{lappend faces \{000 100 110 010\}\}
\}

CheckBox xyPlane 0 -title \"xy-plane\" \\
  -in cbox -at \{2 0\}
}
  {always 1 each}
  {{ list 0.66666667 0.66666667 0.66666667} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::DataFromSurface Create Calculus-11/Surface/Surface {
  {#
#  The graph of the surface is taken from
#  the prototype so that we can turn it
#  on and off without recomputing it.
#

ShowMe show
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {::sd::Patch 0 0 .25}
}
