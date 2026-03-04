#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Calculus-Part2.cs
#  Created:  Fri Nov 19 16:32:05 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Calculus-6 {
  {#
#  This example lets the student investigate the
#  rate of change of a function at a point as
#  we move away from the point in different
#  directions.  This concept will become the
#  \"directional derivative\", but here we simply
#  want them to recognize that in some directions
#  the value of the function increases, in some
#  it decreases, and in some it stays the same.
#
#  Students can be asked to experimentally find
#  the directions in which the change is zero, and
#  the directions where it is greatest and least.
#  They can then conjecture that these are always
#  perpendicular directions.
#

#
#  The window and some frames for the controls.
#
Window controls -rows \{1 1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -rows \{1 1 1 1\} -columns 1 -relief raised -bd 2
Frame cbox -in fbox -at \{0 3\} -bd 2

#
#  The function and its domain.
#
TypeIn f \"2+(x^2+y^2)/2\" -title \"z = f(x,y) =\" \\
  -titlewidth 11 -width 30 -in fbox -at \{0 0\}
TypeIn XY \"\{-1 3 10\} \{-2 2 10\}\" -evaluate \\
  -title \"Domain:\" -titlewidth 11 \\
  -in fbox -at \{0 1\}

#
#  Break the domain into its components.
#

Setup \{let ((xm,xM,xn),(ym,yM,yn)) = XY\}

#
#  A procedure for evaluating f at (x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-6/Point {
  {#
#  This group collects together stuff that happens
#  at this point (so we don't have to recompute
#  the surface when the point changes).
#

TypeIn p0 \"(1.5,.75)\" -evaluate -title \"(x,y) =\" \\
  -titlewidth 11 -in fbox -at \{0 2\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-6/Point/Slice {
  {#
#  The directional derivative is the slope
#  of the tangent line to a slice of the function
#  in the given direction.  This object shows
#  that slice.
#

#
#  Some frames to put things in.
#
Frame slice -in controls -at \{0 1\} \\
  -rows \{1 1 1\} -columns 1 -relief raised -bd 2
Frame sbox -in slice -at \{0 0\} -bd 2 \\
  -rows \{1 1\} -columns \{\{1 10\} 1 1 1\}

#
#  The angle for the slice
#
Slider t 0 2pi 0 -in controls -at \{0 2\}

#
#  The direction based on the angle (the user
#  can also type in a specific direcetion, like
#  (1,0) or (0,1)).
#
TypeIn u \"(cos t, sin t)\" -evaluate \\
  -title \"Slice direction:\" -titlewidth 16 \\
  -in slice -at \{0 1\} -disabled

#
#  The domain for the slicing plane.
#
TypeIn T \"\{-3 2\} \{0 7\}\" -evaluate \\
  -title \"Slice domain:\" -titlewidth 16 \\
  -in slice -at \{0 2\} -disabled

#
#  We make the vector a unit vector (in case
#  the user typed a different one) and break
#  up the plane domain.
#
Setup \{
  let u = Unit(u)
  let ((tm,tM),(zm,zM)) = T
\}

CheckBox show 0 -title \"Slice:\" \\
  -in sbox -at \{1 1 1 2\} -command EnableDisable
ShowMe show

#
#  The slice checkboxes are disabled until
#  the slice checkbox is selected.  This routine
#  asks each of the children to enable or disable
#  their checkboxes accordingly.  We also change
#  the state of the direction and domain typeins.
#  Afterward, we do an update to make sure
#  everything is showing (or not).
#
proc EnableDisable \{\} \{
  variable show
  set action [lindex \{Disable Enable\} $show]
  foreach child \{Curve Direction Plane Tangent\} \\
    \{Child $child CheckBox $child $action\}
  Self TypeIn \{u Disable; T Disable\}
  Update
\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Calculus-6/Point/Slice/Curve {
  {#
#  The curve on the surface above the line
#  in the slice direction.
#

Domain \{tm tM 24\}

Function \{t\} \{
  let (x,y) = p0 + t u
\}

CheckBox Curve 0 -in sbox -at \{3 1\} -disabled
ShowMe Curve}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {0 3}
  {::cd::Solid}
}

####################

::class::Arrows Create Calculus-6/Point/Slice/Direction {
  {#
#  This is an arrow pointing in the direction
#  for which we want to find the rate of change of
#  the function f.

Vertices \{p0 (p0 + tM u)\}
Arrows \{\{0 1\}\}
ArrowHead .3 .075 -relative -outline

CheckBox Direction 1 -in sbox -at \{2 1\} -disabled
ShowMe Direction

Axes \{x y\}}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-6/Point/Slice/Plane {
  {#
#  This is the slicing plane above the direction
#  we are interested in.
#

Domain \{\{tm tM 1\} \{zm zM 1\}\}

Function \{t z\} \{
  let (x,y) = p0 + t u
\}

CheckBox Plane 0 -in sbox -at \{2 2\} -disabled
ShowMe Plane}
  {always 1 each}
  {{ list 1 0 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Curve Create Calculus-6/Point/Slice/Tangent {
  {#
#  This is the tangent line to the curve on
#  the surface.  Its slope is the directional
#  derivative of f at the point in the given
#  direction.
#  

Domain \{tm tM 24\}

Function \{t\} \{
  let (x,y) = p0 + t u
  let z = z0 + t m
\}

#
#  To find the slope, we call the curve's Df
#  function, which returns the tangent vector
#  to the curve (this object links to the curve
#  on the surface).  The third component is the
#  slope.
#
#  We also compute the height at the given point,
#  and set the typeout to display the slope.
#
Setup \{
  let (dx,dy,m) = [Object Df 0]
  let z0 = F(p0)
  if \{$Tangent\} \{set df $m\} else \{set df \"\"\}
\}

CheckBox Tangent 0 -title \"Tangent Line\" \\
  -in sbox -at \{3 2\} -disabled
ShowMe Tangent

#
#  The slope is displayed in this typeout
#
Frame tbox -in controls -at \{0 3\} \\
  -rows 1 -relief raised -bd 2 -bg grey75
TypeOut df -title \"Slope of tagent line:\" \\
  -in tbox -at \{0 0\}}
  {always 1 each}
  {{ list 0 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 0}
  {::cd::Solid}
}

####################

::class::Polyhedron Create Calculus-6/Point/Upright {
  {#
#  This is the vertical line from the point in the
#  xy-plane to the point on the function graph.
#

Vertices \{
 xy:  p0
 fxy: p0::F(p0)
\}

Faces \{ \{xy fxy\} \}}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Calculus-6/Surface {
  {#
#  This is the graph of the surface plus
#  an indication of the domain.
#

CheckBox show 1 -title \"Show Surface Graph\" \\
  -in cbox -at \{0 0\}
ShowMe show}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Calculus-6/Surface/Domain {
  {#
#  The usual domain with vertical lines
#  to the surface at the corners of the domain.
#

Vertices \{
 000: (xm,ym,0)   001: (xm,ym,F(xm,ym))
 010: (xM,ym,0)   011: (xM,ym,F(xM,ym))
 100: (xm,yM,0)   101: (xm,yM,F(xm,yM))
 110: (xM,yM,0)   111: (xM,yM,F(xM,yM))
\}

Faces \{
 \{\{000 001\}
  \{010 011\}
  \{100 101\}
  \{110 111\}\} <- \{width 2\}
 \{000 010 110 100\} <- outline
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-6/Surface/Graph {
  {#
#  The graph of the function with a black border.
#

Domain \{
  \{\{xm xM xn\} \{ym yM yn\}\}
  \{\{xm xM xn\} \{ym yM 1\}  LinesU \{0 0 0\}\}
  \{\{xm xM 1\}  \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {3 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-7 {
  {#
#  This sample shows how the partial derivatives
#  are computed as the slopes of the tangent
#  lines in the directions parallel to the
#  coordinate axes.
#

#
#  The control window and some frames.
#
Window controls -rows \{1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -relief raised -bd 2 \\
  -rows \{1 1 1 1\} -columns \{1 0 1\}
Frame partials -in controls -at \{0 1\} \\
  -relief raised -bd 2 -rows \{1 1\} -columns \{1 1\}

#
#  The function and its domain.
#
TypeIn f \"6-(x^2+y^2)/2\" -title \"z = f(x,y) =\" \\
  -in fbox -at \{0 0 3 1\} -titlewidth 11
TypeIn XY \"\{-1 3 10\} \{-1 3 10\}\" -title \"Domain:\" \\
  -in fbox -at \{0 1 3 1\} -titlewidth 11 -width 25

#
#  We break up the domain into its components.
#
Setup \{let ((xm,xM,xn),(ym,yM,yn)) = XY\}

#
#  A procedure for evaluating f at (x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-7/Point {
  {#
#  This is a group to collect together all
#  the objects that depend on the point below.
#

TypeIn p0 \"(1.5,1)\" -title \"(x,y) =\" -evaluate \\
  -in fbox -at \{0 2 3 1\} -titlewidth 11

TypeIn TZ \"\{-2 2\} \{-1 7\}\" -evaluate \\
  -title \"Domain for planes:\" \\
  -in partials -at \{0 1 2 1\}

Setup \{let ((tm,tM),(zm,zM)) = TZ\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Calculus-7/Point/Upright {
  {#
#  The line segment from the point in the plane
#  to the point on the function graph.
#

Vertices \{
 xy:  p0
 fxy: p0::F(p0)
\}

Faces \{\{xy fxy\}\}
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Calculus-7/Point/X-partial {
  {#
#  This group collects together the objects needed
#  to show the partial derivative in x.
#

#
#  This frame holds the checkboxes for the x partial.
#
Frame xpartial -in partials -at \{0 0\} -bd 2 \\
  -columns \{\{0 15\} 0\}

#
#  The checkboxes for the parts are only active
#  when this one is checked.
#
CheckBox show 0 -title \"x-Partial:\" \\
  -in xpartial -at \{0 0 2 1\} -command EnableDisable
ShowMe show

#
#  This procedure makes the checkboxes in the
#  children objects available or not depending
#  on the state of the checkbox above.
#  
proc EnableDisable \{\} \{
  variable show
  set action [lindex \{Disable Enable\} $show]
  foreach child \{Curve Plane Tangent\} \\
    \{Child $child CheckBox $child $action\}
  Update
\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Calculus-7/Point/X-partial/Curve {
  {#
#  This is the curve along the surface whose
#  derivative is the x partial derivative.
#

Domain \{tm tM 20\}
Function \{t\} \{let (x,y) = p0 + (t,0)\}

CheckBox Curve 0 -in xpartial -at \{1 2\} -disabled
ShowMe Curve}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {1 4}
  {::cd::Solid}
}

####################

::class::Surface Create Calculus-7/Point/X-partial/Plane {
  {#
#  This is the plane parallel to the xz-plane
#  that slices the surface in the curve that
#  produces the partial derivative with respect
#  to x.
#

Domain \{\{tm tM 1\} \{zm zM 1\}\}
Function \{t z\} \{let (x,y) = p0 + (t,0)\}

CheckBox Plane 1 -in xpartial -at \{1 1\} -disabled
ShowMe Plane}
  {always 1 each}
  {{ list 0.558 0.62 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::CurveVectors Create Calculus-7/Point/X-partial/Tangent {
  {#
#  This is the tangent vector that represents
#  the x partial derivative.  Its coordinates
#  are (1,0,f_x), so its z-coordinate is the
#  partial derivative.
#  

Domain \{0 0 1\}

ArrowScale 2
ArrowHead .25 .075 -outline -relative

CheckBox Tangent 0 -in xpartial -at \{1 3\} -disabled
ShowMe Tangent

#
#  We show the value of the derivative by
#  getting the third coordinate of the
#  derivative vector for the linked curve.
#
TypeOut fx -width 7 -title \"f_x =\"\\
  -in xpartial -at \{0 4 2 1\}

Setup \{
  if \{$Tangent\} \{let (x,y,fx) = [Object Df 0]\} \\
    else \{set fx \"\"\}
\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 1}
  {1 0 0 0 0 0 0 0 1}
}

####################

::class::Group Create Calculus-7/Point/Y-partial {
  {#
#  This group collects together the objects needed
#  to show the partial derivative in y.
#

#
#  This frame holds the checkboxes for the y partial.
#
Frame ypartial -in partials -at \{1 0\} -bd 2 \\
  -columns \{\{0 15\} 0\}

#
#  The checkboxes for the parts are only active
#  when this one is checked.
#
CheckBox show 0 -title \"y-Partial:\" \\
  -in ypartial -at \{0 0 2 1\} -command EnableDisable
ShowMe show

#
#  This procedure makes the checkboxes in the
#  children objects available or not depending
#  on the state of the checkbox above.
#  
proc EnableDisable \{\} \{
  variable show
  set action [lindex \{Disable Enable\} $show]
  foreach child \{Curve Plane Tangent\} \\
    \{Child $child CheckBox $child $action\}
  Update
\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Calculus-7/Point/Y-partial/Curve {
  {#
#  This is the curve along the surface whose
#  derivative is the y partial derivative.
#

Domain \{tm tM 10\}
Function \{t\} \{let (x,y) = p0 + (0,t)\}

CheckBox Curve 0 -in ypartial -at \{1 2\} -disabled
ShowMe Curve}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {2 4}
  {::cd::Solid}
}

####################

::class::Surface Create Calculus-7/Point/Y-partial/Plane {
  {#
#  This is the plane parallel to the yz-plane
#  that slices the surface in the curve that
#  produces the partial derivative with respect
#  to y.
#

Domain \{\{tm tM 1\} \{zm zM 1\}\}
Function \{t z\} \{let (x,y) = p0 + (0,t)\}

CheckBox Plane 1 -in ypartial -at \{1 1\} -disabled
ShowMe Plane}
  {always 1 each}
  {{ list 0.7 0.474 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::CurveVectors Create Calculus-7/Point/Y-partial/Tangent {
  {#
#  This is the tangent vector that represents
#  the x partial derivative.  Its coordinates
#  are (0,1,f_y), so its z-coordinate is the
#  partial derivative.
#  

Domain \{0 0 1\}

ArrowScale 2
ArrowHead .25 .075 -outline -relative

CheckBox Tangent 0 -in ypartial -at \{1 3\} -disabled
ShowMe Tangent

#
#  We show the value of the derivative by
#  getting the third coordinate of the
#  derivative vector for the linked curve.
#
TypeOut fy -width 7 -title \"f_y =\"\\
  -in ypartial -at \{0 4 2 1\}

Setup \{
  if \{$Tangent\} \{let (x,y,fy) = [Object Df 0]\} \\
   else \{set fy \"\"\}
\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 2}
  {1 0 0 0 0 0 0 0 1}
}

####################

::class::Group Create Calculus-7/Surface {
  {#
#  The usual surface graph with its domain.
#

CheckBox show 1 -title \"Show Surface Graph\" \\
  -in fbox -at \{1 3\}
ShowMe show}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Calculus-7/Surface/Domain {
  {Vertices \{
 000: (xm,ym,0)   001: (xm,ym,F(xm,ym))
 010: (xM,ym,0)   011: (xM,ym,F(xM,ym))
 100: (xm,yM,0)   101: (xm,yM,F(xm,yM))
 110: (xM,yM,0)   111: (xM,yM,F(xM,yM))
\}

Faces \{
 \{000 001\}
 \{010 011\}
 \{100 101\}
 \{110 111\}
 \{000 010 110 100\} <- outline
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-7/Surface/Graph {
  {Domain \{
  \{\{xm xM xn\} \{ym yM yn\}\}
  \{\{xm xM xn\} \{ym yM 1\}  LinesU \{0 0 0\}\}
  \{\{xm xM 1\}  \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {4 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-8 {
  {#
#  This examples hows how the partial derivative
#  vectors can be used to form the tangent plane,
#  and in turn this tangent plane can be used to
#  compute the directional derivative for any
#  direction.  This motivates the definition
#  of the gradient vector, and generates the
#  standard formula for computing the directional
#  derivative of f in the direction u:
#
#      Df_u = Grad(f) . u
#
#  The user should check the items in the first
#  column and then the ones in the second column
#  of the control panel.
#
#  The \"show vector components\" checkbox can be
#  used to see the vertical components (which
#  represent the actual derivatives in the given
#  directions).
#

#
#  The window and frames for the control panel.
#
Window controls -rows \{1 1 1 1 1 1 1\} -columns 1
Frame cbox -in controls -at \{0 4\} -bd 2 \\
  -rows \{1 1 1\} -columns \{1 0 1\}

#
#  The function and its domain.
#
TypeIn f \"6-(x^2+y^2)/4\" -title \"z = f(x,y) =\" \\
  -in controls -at \{0 0\} -titlewidth 11 -width 30
TypeIn XY \"\{-1 3 10\} \{-1 3 10\}\" -evaluate \\
  -title \"Domain:\" -titlewidth 11 \\
  -in controls -at \{0 1\}

#
#  Break up the domain into its components.
#
Setup \{let ((xm,xM,xn),(ym,yM,yn)) = XY\}

#
#  A procedure for evaluating f at (x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-8/Point {
  {#
#  This group collects togehter all the things
#  that depend on the point given below.
#

TypeIn p0 \"(1.5,1)\" -title \"(x,y) =\" -evaluate \\
  -in controls -at \{0 2\} -titlewidth 11

TypeIn tm \"1.0\" -evaluate \\
  -title \"Width of Tangent Plane:\" \\
  -in controls -at \{0 6\}

Frame checks -in cbox -at \{0 1 5 1\} -bd 2 \\
  -columns \{1 0 1 0 1\} -bd 2

#
#  We put the point into three-space, and compute
#  the location of the point on the graph.
#
Setup \{
  let P0 = p0::0
  let F0 = p0::F(p0)
\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-8/Point/Curves {
  {#
#  These are the two curves parallel to the
#  xz- and yz-planes from which the partial
#  derivatives are computed.
#

CheckBox Traces 0 -in checks -at \{1 1\}
ShowMe Traces
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Calculus-8/Point/Curves/X-trace {
  {Domain \{-tm tm 10\}

Function \{t\} \{let (x,y) = p0 + (t,0)\}
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 5}
  {::cd::Solid}
}

####################

::class::CurveOnSurface Create Calculus-8/Point/Curves/Y-trace {
  {Domain \{-tm tm 10\}

Function \{t\} \{let (x,y) = p0 + (0,t)\}
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 5}
  {::cd::Solid}
}

####################

::class::Vectors Create Calculus-8/Point/Normal {
  {#
#  This is a vector based at the point on the
#  graph in the direction of the surface normal
#  at that point.
#

#
#  Since this object is linked to the surface,
#  the Object() function can be used to ask
#  the surface to compute its normal vector.
#
Vectors \{
  \{F0 Unit(Object(\"Normal\",p0))\}
\}

ArrowScale 2
ArrowHead .25 .075 -outline -relative

CheckBox Normal 0 -in checks -at \{3 0\}
ShowMe Normal}
  {always 1 each}
  {{ list 1 .5 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 5}
}

####################

::class::Surface Create Calculus-8/Point/TangentPlane {
  {#
#  This is the tangent plane at the point
#  on the surface.
#  

#
#  We represent the plane parametrically
#  based at the point on the graph, using the
#  two partial derivative vectors as the
#  directions for the plane.
#
Domain \{\{-tm tm 1\} \{-tm tm 1\}\}
Function \{t s\} \{
  let (x,y,z) = F0 + t V1 + s V2
\}

#
#  This object is linked to the surface graph.
#  To get the partial derivative vectors,
#  we call the linked object's Fu and Fv
#  functions.
#
Setup \{
 let V1 = Object(\"Fu\",p0)
 let V2 = Object(\"Fv\",p0)
\}

CheckBox Tangent 0 -title \"Tangent Plane\" \\
  -in checks -at \{3 1\}
ShowMe Tangent}
  {always 1 each}
  {{ list 1 0.944 0.61} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {::sd::Patch 0 0 .25}
}

####################

::class::Polyhedron Create Calculus-8/Point/Upright {
  {#
#  This is the segment from the point in the
#  xy-plane up to the pointon the graph.
#

Faces \{\{P0 F0\}\}

#
#  This object is linked to the Surface object,
#  and is shown only when it is.  The variable
#  \"show\" is inherited from that object.
#
ShowMe show
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 6}
}

####################

::class::Group Create Calculus-8/Point/Vectors {
  {#
#  This group collects the parts needed to show
#  the derivative vectors.
#

#
#  This tells whether vectors are decomposed into
#  their components (the vertical ones are of
#  length equal to the derivatives).
#
CheckBox components 1 -in cbox -at \{1 2\} \\
  -title \"Show Vector Compontents\"

#
#  This tells whether to show the directions
#  down in the xy-plane.
#
CheckBox directions 0 -in checks -at \{1 0\} \\
  -title \"Directions\"

#
#  This is for output of the gradient and Df_u.
#
Frame gbox -in controls -at \{0 5\} \\
  -rows 1 -columns \{1 1\} -bg grey75 -bd 2

#
#  We get the gradient vectors for use by the
#  children objects.  Since we are linked
#  to the Surface/Graph object, the Object()
#  function can be used to ask it to compute
#  its gradient vector.
#
Setup \{let Df = (fx,fy) = Object(\"Gradient\",p0)\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
}

####################

::class::Vectors Create Calculus-8/Point/Vectors/Df_u {
  {#
#  This shows the directional derivative vector
#  and its components.
#

#
#  The vectors are computed below
#
Vectors \{$vectors\}

ArrowScale tm
ArrowHead .25 .075 -outline -relative

#
#  The direction for the derivative.
#
TypeIn u \"(2,1)\" -evaluate -title \"u =\" \\
  -titlewidth 11 -in controls -at \{0 3\}

#
#  A place to display the directional derivative.
#
TypeOut df -title \"Df_u =\" -width 6 \\
  -in gbox -at \{1 0\}

CheckBox show 0 -title \"Df_u\" -in checks -at \{3 2\}
ShowMe \{show || directions\}

#
#  Here we get the unit vector in the specified
#  direction.  Then we display the directional
#  derivative in the typeout.  Finally, we create
#  the list of vectors needed to display the
#  directional derivative.
#
Setup \{
  let u = Unit(u); let U = u::0

  if \{!$show\} \{set df \"\"\} else \\
    \{let df = format(\"%.3g\",Df.u)\}

  set vectors \{\}

  if \{$show\}  \{lappend vectors \{F0 (u::(Df.u))\}\}

  if \{$directions\} \{lappend vectors \{P0 U\}\}

  if \{$components && $show\} \{
   append vectors \{
     \{F0 U\} <- \{head \{.2 .05\}\}
     \{F0+tm*U (0,0,(Df.u))\}
        <- \{head \{0 0\} color \{.3 .3 .3\}\}
    \}
  \}
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Vectors Create Calculus-8/Point/Vectors/Partials {
  {#
#  This shows the partial derivative vectors
#  and their components.
#

#
#  The vectors are computed below.
#
Vectors \{$vectors\}

ArrowScale tm
ArrowHead .25 .075 -outline -relative


#
#  A place to show the vector of partials.
#
TypeOut gradf -title \"Grad(f) =\" -width 7\\
  -in gbox -at \{0 0\}

#
#  We display the gradient vector, if needed,
#  then put together the list of vectors
#  needed to display the requested parts.
#
Setup \{
  if \{!$show\} \{set gradf \"\"\} else \\
   \{set gradf [format \"(%.2g,%.2g)\" $fx $fy]\}

  set vectors \{\}

  if \{$show\} \\
   \{lappend vectors \{F0 (1,0,fx)\} \{F0 (0,1,fy)\}\}

  if \{$directions\} \\
   \{lappend vectors \{P0 (1,0,0)\} \{P0 (0,1,0)\}\}

  if \{$components && $show\} \{
   append vectors \{
    \{F0 (1,0,0)\} <- \{head \{.2 .05\}\}
    \{F0 (0,1,0)\} <- \{head \{.2 .05\}\}
    \{F0+(tm,0,0) (0,0,fx)\}
       <- \{head \{0 0\} color \{1 .5 .5\}\}
    \{F0+(0,tm,0) (0,0,fy)\}
       <- \{head \{0 0\} color \{1 .5 .5\}\}
   \}
  \}
\}

CheckBox show 0 -title \"Partials\" -in checks -at \{1 2\}
ShowMe \{show || directions\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Calculus-8/Surface {
  {#
#  The usual surface graph with domain.
#

Frame center -in cbox -at \{1 0\}
CheckBox show 1 -title \"Show Surface\" \\
  -in center -at \{0 0\}
ShowMe show}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {6 {}}
}

####################

::class::Polyhedron Create Calculus-8/Surface/Domain {
  {Vertices \{
 000: (xm,ym,0)   001: (xm,ym,F(xm,ym))
 010: (xM,ym,0)   011: (xM,ym,F(xM,ym))
 100: (xm,yM,0)   101: (xm,yM,F(xm,yM))
 110: (xM,yM,0)   111: (xM,yM,F(xM,yM))
\}

Faces \{
 \{000 001\}
 \{010 011\}
 \{100 101\}
 \{110 111\}
 \{000 010 110 100\} <- outline
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-8/Surface/Graph {
  {Domain \{
  \{\{xm xM xn\} \{ym yM yn\}\}
  \{\{xm xM xn\} \{ym yM 1\}  LinesU \{0 0 0\}\}
  \{\{xm xM 1\}  \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {5 {}}
  {::sd::Patch 0 0 .25}
}
