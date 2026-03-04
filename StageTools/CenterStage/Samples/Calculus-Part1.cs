#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Calculus-Part1.cs
#  Created:  Thu Nov 18 16:23:54 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Calculus-1 {
  {#
#  This example shows a cuve in either 2 or 3
#  dimensions, together with several important
#  vectors at a point on the curve.
#
#  The student can select which vectors to show
#  and can move the point via a slider.  He can
#  also change the function and its domain to
#  investigate other functions.
#
#  The initial function has a constant upward
#  acceleration.  Other interesting functions
#  To view are f(t) = (t,t^3) and f(t) = (t^2,t^3).
#  The students can look for what happens to
#  the normal vector when the acceleration goes
#  to zero, and what happens to the tangent
#  vector when the velocity goes to zero.
#

#
#  Windows and frames for the controls
#
Window controls -rows \{1 1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -rows \{1 1\} -columns 1 -relief raised -bd 2
Frame cbox -in fbox -at \{0 2\} -bd 2\\
  -rows 1 -columns \{1 1 1 1 1\}

#
#  The function and its domain
#
TypeIn f \"(t,t^2)\" -title \"f(t) =\" \\
  -in fbox -at \{0 0\} -titlewidth 8
TypeIn D \"\{-1 1 24\}\" -title \"Domain:\" -evaluate \\
  -in fbox -at \{0 1\} -titlewidth 8

#
#  A function that evaluates f(t)
#
vproc F \{t\} \{
  variable f
  let X = ($f)
  return $X
\}

#
#  We split up the domain into its parts, and
#  find the longest dimension (for use with the
#  axes).  The function is planar if it has only
#  two components.
#
Setup \{
  let (tm,tM,tn) = D
  let len = 1.3 Max(abs(tm),abs(tM))
  let isPlanar = llength(:F(tm):) == 2
\}}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 0 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Calculus-1/Axes {
  {#
#  Here we scale the axes to accommodate the
#  function's domain (not always very well),
#  and if the function is planar, we eliminate
#  the z-axis by scaling it to 0.
#
Length \{len len 1-isPlanar\}

Axes \{x y z\}

ArrowHead .15 .025 -outline}
  {always 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}

####################

::class::Curve Create Calculus-1/Curve {
  {#
#  Here we set x, y and z to the function's value
#  (and use 0.01 for a planar function so that
#  it will appear on top of the axes).
#

Domain \{tm tM tn\}

Function \{t\} \{
  if \{$isPlanar\} \{let (x,y,z) = F(t)::0.01\} \\
    else \{let (x,y,z) = F(t)\}
\}}
  {always 1 keep}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {0 {}}
  {::cd::Solid}
}

####################

::class::Group Create Calculus-1/Spot {
  {#
#  This group shows the vectors at the movable
#  point along the curve.
#

#
#  We use a normalized slider to get the
#  position of the point within the domain...
#
Slider t 0 1 0 -title \"Position:\" \\
  -in controls -at \{0 1\}

#
#  ...and display the actual value here.
#
Frame tbox -in controls -at \{0 2\} \\
  -relief raised -bd 2 -bg grey75
TypeOut tt -title \"Point is at t =\" \\
  -in tbox -at \{0 0\}

#
#  We compute the actual t value of the point
#  as a linear interpolation between the two
#  endpoints of the domain for f.
#
Setup \{let tt = (1-t) tm + t tM\}
}
  {always 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveVectors Create Calculus-1/Spot/Acceleration {
  {#
#  We get an acceleration vector at the point
#
Domain \{tt tt 1\}

ArrowHead .3 .05 .3 .075 -outline -relative

CheckBox Acceleration 0 -in cbox -at \{2 0\}
ShowMe Acceleration}
  {always 1 keep}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
  {0 0 0 0 1 0 0 0 0}
}

####################

::class::CurveVectors Create Calculus-1/Spot/Normal {
  {#
#  We get a unit normal vector at the point.
#
Domain \{tt tt 1\}

ArrowHead .3 .05 .3 .075 -outline -relative

CheckBox Normal 0 -in cbox -at \{4 0\}
ShowMe Normal}
  {always 1 keep}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
  {0 1 0 0 0 0 0 0 0}
}

####################

::class::Polyhedron Create Calculus-1/Spot/Point {
  {#
#  Here we compute the point on the curve (and
#  if it is a planar curve, we raise the point
#  so that it is above the curve and axes)
#  and make a single face consiting of the single
#  point.
#

Faces \{ \{p\} \}

Setup \{
  if \{$isPlanar\} \{let p = F(tt)::.03\} \\
    else \{let p = F(tt)\}
\}
}
  {always 1 keep}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 10 1 0 0 0 0 0 0 0 0 1.0 10}
  {{} {}}
}

####################

::class::CurveVectors Create Calculus-1/Spot/Tangent {
  {#
#  We get a unit tangent vector at the point
#
Domain \{tt tt 1\}

ArrowHead .3 .05 .3 .075 -outline -relative

CheckBox Tangent 0 -in cbox -at \{3 0\}
ShowMe Tangent}
  {always 1 keep}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
  {1 0 0 0 0 0 0 0 0}
}

####################

::class::CurveVectors Create Calculus-1/Spot/Velocity {
  {#
#  We get the velocity vector at the point
#

Domain \{tt tt 1\}

ArrowHead .3 .05 .3 .075 -outline -relative

CheckBox Velocity 0 -in cbox -at \{1 0\}
ShowMe Velocity}
  {always 1 keep}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
  {0 0 0 1 0 0 0 0 0}
}

####################

::class::Group Create Calculus-2 {
  {#
#  This example allows students to investigate
#  the graph of a function f:R^2 -> R.  They
#  can plug in different functions and see their
#  graphs.  They can evaluate the function at a
#  point to see its value and how the point in the
#  xy-plane has been raised up that distance to
#  be plotted on the graph.
#  

#
#  The windows and frames for the widgets.
#
Window controls -rows \{1 1 1\} -columns 1
Frame cbox -in controls -at \{0 2\} -bd 2 \\
  -rows 1 -columns \{1 1 1 1 1\}

#
#  The function and its domain.
#
TypeIn f \"x^2 + y^2\" -width 30 \\
  -title \"z = f(x,y) =\" -titlewidth 11 \\
  -in controls -at \{0 0\}
TypeIn xy \"\{-1 1 10\} \{-1 1 10\}\" -evaluate \\
  -title \"Domain:\" -titlewidth 11 \\
  -in controls -at \{0 1\}

#
#  We extract the domain components and find
#  the longest one (for the axes and xy-plane)
#
Setup \{
  let ((xm,xM,xn),(ym,yM,yn)) = xy
  let len = Max(abs(xm),abs(xM),abs(ym),abs(yM))
  let XY = ((-len,len,1),(-len,len,1))
  let len = 1.3 len
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Calculus-2/Axes {
  {#
#  A set of axes scaled to match the domain.
#

Length len

Axes \{x y z\}

CheckBox Axes 1 -in cbox -at \{1 0\}
ShowMe Axes
}
  {always 1 each}
  {{::_color::Function RGB} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Calculus-2/Point {
  {#
#  This object shows a vertical line above the
#  point point in the xy-plane and of length
#  equal to the value of the function at that
#  point.  This shows how that graph is made
#  by \"lifting\" each of the points in the xy-plane
#  to their proper heights.
#

#
#  A function for evaluating f(x,y).
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}


Frame point -in controls -at \{0 3\} \\
  -rows 1 -columns \{1 1\} -bg grey75 -bd 2

#
#  This lets the user specify a point in the
#  xy-plane...
#
TypeIn xy \"(.5,.5)\" -evaluate -width 10\\
  -title \"z at\" -in point -at \{0 0\}

#
#  ... and displays the value of f at that point.
#
let fxy = F(xy)
TypeOut fxy -title \"is\" \\
  -in point -at \{1 0\} -width 10
Setup \{let fxy = F(xy)\}

#
#  The line segment above (x,y).
#
Faces \{\{xy::0 xy::fxy\}\}

CheckBox Point 0 -in cbox -at \{4 0\}
ShowMe Point
}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-2/Surface {
  {#
#  This displays the given surface as a graph
#  of the function f(x,y) over the specified
#  domain.
#

Domain \{$xy\}
Function \{x y\} \{let z = ($f)\}

CheckBox Surface 1 -in cbox -at \{2 0\}
ShowMe Surface}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Calculus-2/xy-Plane {
  {#
#  This is a plane at height z=0 with the
#  dimensions calculated in the main group's
#  Setup directive.
#
Domain \{$XY\}
Function \{x y\} \{let z = 0\}

CheckBox plane 1 -title \"xy-Plane\" \\
  -in cbox -at \{3 0\}
ShowMe plane
}
  {always 1 each}
  {{ list 1 0 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-3 {
  {#
#  This example computes the xz and yz traces
#  of a surface given as the graph of a funtion
#  f:R^2 -> R (i.e., the images of the lines
#  where y or x is held constant at some value.
#
#  The user can show a single trace (together
#  with the line in the xy-plane of which it is
#  an image), or a series of traces on the surface.
#  The position of a single trace is given by
#  a normalized slider.
#

#
#  The window and frames for the widgets.
#
Window controls -rows \{1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows \{1 1 1 1\} -columns 1
Frame cbox -in fbox -at \{0 2\} \\
  -rows 1 -columns \{1 1 1 1 1\}
Frame tbox -in fbox -at \{0 3\} -bd 2 \\
  -rows 1 -columns \{1 0 0 \{1 10\} 1\}

#
#  The function and its domain.
#
TypeIn f \"x^2 + y^2\" -width 30 \\
  -title \"z = f(x,y) =\" -titlewidth 11 \\
  -in fbox -at \{0 0\}
TypeIn xy \"\{-1 1 10\} \{-1 1 10\}\" -evaluate \\
  -title \"Domain:\" -titlewidth 11 \\
  -in fbox -at \{0 1\}

#
#  We split the domain into its components
#  and find the length to use for the axes.
#
Setup \{
  let ((xm,xM,xn),(ym,yM,yn)) = xy
  let len = 1.3 Max(abs(xm),abs(xM),abs(ym),abs(yM))
\}

#
#  A function for evaluating f at (x,y).
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

::class::Axes Create Calculus-3/Axes {
  {#
#  Axes of the proper length.
#
Length len

Axes \{x y z\}

CheckBox Axes 1 -in cbox -at \{1 0\}
ShowMe Axes
}
  {always 1 each}
  {{::_color::Function RGB} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Calculus-3/Surface {
  {#
#  This group includes the surface (with
#  a black border) together with a representation
#  of its domain.
#}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Calculus-3/Surface/Border {
  {#
#  This is the black border for the surface.
#

Domain \{
  \{\{xm xM xn\} \{ym yM 1\} LinesU \{0 0 0\}\}
  \{\{xm xM 1\} \{ym yM yn\} LinesV \{0 0 0\}\}
\}

Function \{x y\} \{let z = ($f)\}
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Polyhedron Create Calculus-3/Surface/Domain {
  {#
#  The vertices are the corners of the domain
#  and the corners raised up to the graph.
#
Vertices \{
 000: (xm,ym,0)   001: (xm,ym,F(xm,ym))
 010: (xM,ym,0)   011: (xM,ym,F(xM,ym))
 100: (xm,yM,0)   101: (xm,yM,F(xm,yM))
 110: (yM,yM,0)   111: (xM,yM,F(xM,yM))
\}

#
#  These make a set of uprights at the corners
#  together with the outline of the xy-plane.
#
Faces \{
 \{000 001\}
 \{010 011\}
 \{100 101\}
 \{110 111\}
 \{000 010 110 100\} <- outline
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}

####################

::class::Surface Create Calculus-3/Surface/Graph {
  {#
#  Here is the graph of the function.
#
Domain \{$xy\}
Function \{x y\} \{let z = ($f)\}

CheckBox Surface 1 -in cbox -at \{2 0\}
ShowMe Surface}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {1 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-3/Traces {
  {#
#  This group shows the traces.
#

#
#  This menu selects which type of trace to show
#
PopUp xychoice \{x y\} -title \"Trace\" \\
  -in tbox -at \{1 0\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Calculus-3/Traces/Many {
  {#
#  To show many traces, we either use the
#  LinesU and LinesV domain styles (and set
#  the lines to be colored by the correct
#  parameter to make each line a constant
#  color).
#

Domain \{[concat $xy $style]\}
Function \{x y\} \{let z = ($f)\}

Setup \{
  if \{$xychoice == \"x\"\} \\
   \{set style \"LinesU y\"\} else \\
   \{set style \"LinesV x\"\}
\}

CheckBox show 0 -title \"Many Traces\" \\
  -in tbox -at \{4 0\}
ShowMe show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-3/Traces/Single {
  {#
#  This group shows a single trace in the
#  selected direction.
#

#
#  This displays the actual position of the
#  trace.
#
TypeOut trace -title \"at \" -in tbox -at \{2 0\}

#
#  The normalized position of the trace.
#
Slider tt 0 1 .5 -title \"Position of trace:\" \\
  -in controls -at \{0 1\} -disabled

#
#  We find the number of subdivisions, the
#  starting point and the direction vector for
#  the type of trace we are displaying.
#  We set the value of the 
Setup \{
  if \{$xychoice == \"x\"\} \{
    set n $xn
    let yy = tt yM + (1-tt) ym
    let p0 = (xm,yy)
    let V  = (xM-xm,0)
    set trace \"y = $yy\"
  \} else \{
    set n $yn
    let xx = tt xM + (1-tt) xm
    let p0 = (xx,ym)
    let V  = (0,yM-ym)
    set trace \"x = $xx\"
  \}
  set action [lindex \{Disable Enable\} $Trace]
  Child Uprights CheckBox Uprights $action
  Self Slider tt $action
\}

CheckBox Trace 0 -in cbox -at \{3 0\}
ShowMe Trace
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Calculus-3/Traces/Single/Curve {
  {#
#  Here we draw the trace curve on the surface;
#  it lies over the given line in the plane.
#

Domain \{0 1 24\}

Function \{t\} \{
  let (x,y) = p0 + t V
\}}
  {always 1 each}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 1}
  {::cd::Solid}
}

####################

::class::Polyhedron Create Calculus-3/Traces/Single/Line {
  {#
#  Here we draw a line as a segment between two
#  points.
#

Vertices \{
 a: p0
 b: p0+V
\}

Faces \{\{a b\}\}}
  {always 1 each}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Surface Create Calculus-3/Traces/Single/Uprights {
  {#
#  This is the set of uprights showing
#  how the line in the plane is \"lifted\" to
#  form the trace on the surface.
#
Domain \{\{0 1 n\} \{0 1 1\}\}

Function \{u v\} \{
  let (x,y) = p0 + u V
  if \{$v == 0\} \{let z = 0\} else \{let z = ($f)\}
\}

#
#  This checkbox is enabled by the Trace checkbox
#  in the parent object.
#
CheckBox Uprights 1 -in cbox -at \{4 0\} -disabled
ShowMe Uprights}
  {always 1 each}
  {{set u} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
  {::sd::LinesV 0 0 .25}
}

####################

::class::Group Create Calculus-4 {
  {#
#  This example lets a student slice a function
#  graph by a plane parallel to the xy-plane at
#  a specified height (or set of heights).  The
#  slices can be seen either on the surface, or
#  projected onto the xy-plane.  If a collection
#  of heights are projected to the xy-plane (and
#  the surface and axes are turned off), this
#  gives the \"contour plot\" of the surface.
#  The user can use the \"Points\" command to
#  specify a collection of equally-spaced heights.
#

#
#  The window and frames for the widgets.
#
Window controls -rows \{1 1 1\} -columns 1
Frame fbox -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows \{1 1 1\} -columns 1
Frame cbox -in fbox -at \{0 2\} -bd 2 \\
  -rows 1 -columns \{1 1 1 1 1\}
Frame sbox -in controls -at \{0 2\} \\
  -relief raised -bd 2 -rows 1 -columns 1

#
#  The function and its domain.
#
TypeIn f \"x^2 + y^2\" -width 30 \\
  -title \"z = f(x,y) =\" -titlewidth 11 \\
  -in fbox -at \{0 0\}
TypeIn xy \"\{-1 1 10\} \{-1 1 10\}\" -evaluate \\
  -title \"Domain:\" -titlewidth 11 \\
  -in fbox -at \{0 1\}

#
#  We determine the components of the domain,
#  and pick the longest one.  This is used to
#  make the domain for the xy-plane, and the
#  length used by the axes.
#
Setup \{
  let ((mx,Mx,nx),(my,My,ny)) = xy
  let len = Max(abs(mx),abs(Mx),abs(my),abs(My))
  let XY = ((-len,len,1),(-len,len,1))
  let len = 1.3 len
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Calculus-4/Axes {
  {#
#  The properly scaled axes.
#

Length len

Axes \{x y z\}

CheckBox Axes 1 -in cbox -at \{1 0\}
ShowMe Axes
}
  {always 1 each}
  {{::_color::Function RGB} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {constant 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Calculus-4/Projected {
  {#
#  This object takes the levels on the surface
#  and projects them back down the the xy-plane.
#

CheckBox plane 0 -in cbox -at \{4 0\} \\
  -title \"in xy-Plane\"
ShowMe plane

Axes \{x y z\} -> \{x y\}

}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create Calculus-4/Projected/Level-k {
  {#
#  This is the projected single level at
#  the height given by k.
#

ShowMe \{heights == \"\"\}}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 2}
}

####################

::class::DataFromPolyhedron Create Calculus-4/Projected/Levels {
  {#
#  This is the set of heights given by the
#  heights typein.
#

ShowMe \{heights != \"\"\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 3}
}

####################

::class::Surface Create Calculus-4/Proto-Surface {
  {#
#  This is a prototype for the function graph
#  being sliced.  it will be computed only once.
#

Domain \{$xy\}
Function \{x y\} \{let z = ($f)\}
}
  {hide 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {4 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-4/Slice {
  {#
#  This group shows the slices of the surface
#  specified wither by the slider or by the
#  typein.  A collection of heights can be
#  specified using the \"Points\" function below.
#

#
#  The height for the slice.
#
Slider k -2 2 0 -in controls -at \{0 1\} \\
  -title \"Slice at height k =\"

#
#  A collection of heights for slicing
#
TypeIn heights \"\" -title \"Or at heights:\" \\
  -in sbox -at \{0 0\} -evaluate

CheckBox show 0 -title \"Slice\" -in cbox -at \{3 0\}
ShowMe show

#
#  This procedure can be used to compute
#  a collection of n equally spaced levels between
#  the heights m and M.
#
proc Points \{m M n\} \{
  ::class::Levels Points [list $m $M] $n
\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Calculus-4/Slice/Level-k {
  {#
#  A single level at the height given by the slider.
#

Height z = k

ShowMe \{heights == \"\"\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {2 4}
}

####################

::class::Levels Create Calculus-4/Slice/Levels {
  {#
#  A collection of levels at the heights given
#  by the typein.
#

Height z at heights

ShowMe \{heights != \"\"\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {3 4}
}

####################

::class::Surface Create Calculus-4/Slice/Plane {
  {#
#  A plane at the height given by the slider.
#  (it won't show if multiple heights are given).
#

Domain \{$XY\}
Function \{x y\} \{let z = k\}

ShowMe \{heights == \"\"\}}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::DataFromSurface Create Calculus-4/Surface {
  {#
#  This is th esurface graph.  It is taken from
#  a prototype so that the levels don't need
#  to be recomputed when we turn the surface
#  on or off.
#

CheckBox Surface 1 -in cbox -at \{2 0\}
ShowMe Surface}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Calculus-5 {
  {#
#  This demonstration analyses the classical
#  example of a surface that has limit zero at
#  the origin along all straight lines, but
#  along a parabola, the limit is 1 (or -1), so
#  the function is discontinuous at the origin.
#
#  Horizontal slices of the surface can be taken
#  to make its shape easier to see.
#
#  The parabolas can be highlighted, and the
#  curves along the lines through the origin
#  can also be shown.  It is also illustrative
#  to look at the yz-traces of the surface as
#  x moves closer and closer to the origin.
#
#  Any of the slicing sequences can be animated.
#
#  The function is:
#
#                2 x^2 y
#      f(x,y) = ---------- .
#                x^4 + y^2
#
#  This is difficult to render using a traditional
#  rectangular grid, since the domain is modified
#  so that the parabolas are along parametric lines
#  of the surface.  This makes for a more accurate
#  graph, though the gridding is no longer regular.
#

#
#  Some values used in parametrizing the surface
#
let a = .4; let b = 1.1

#
#  The window and frames for the control panel.
#
Window controls -rows \{1 1 1\} -columns 1
Frame top -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows \{1 1\}
Frame cbox -in top -at \{0 0\} -columns \{1 1 1\}
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-5/Parabolas {
  {#
#  This group shows the two parabolas
#

CheckBox show 0 -title \"Show Parabolas\" \\
  -in cbox -at \{2 0\}
ShowMe show}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Calculus-5/Parabolas/Lower {
  {#
#  A parametric version of the lower parabola.
#
Domain \{-1 1 24\}

Function \{t\} \{
  let (x,y,z) = (t,-t^2,-1)
\}
}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Curve Create Calculus-5/Parabolas/Upper {
  {#
#  A parametric version of the upper parabola.
#

Domain \{-1 1 24\}

Function \{t\} \{
  let (x,y,z) = (t,t^2,1)
\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Calculus-5/Slices {
  {#
#  This group controls the slice that is being
#  shown.  The user can select from several
#  types of slicing sequences and can set the
#  position from the slider bar, or can animate
#  the sequence.
#


Frame slice -in top -at \{0 2\} -columns \{0 1\} -bd 2

#
#  Menu to select the slice type.
#
PopUp slice \{None Level yz-Trace y=mx\} \\
  -title \"Slice\" -in slice -at \{0 0\}

#
#  The position of the slice is shown here.
#
TypeOut at -title \"at\" -in slice -at \{1 0\}

#
#  The normalized position is given by a slider.
#
Slider k 0 1 -title \"Slice position:\" \\
  -in controls -at \{0 1\} -width 200

#
#  The animator can change the slider for us.
#
Animate Step 24 \{Slider k\} -in controls -at \{0 2\}

ShowMe \{slice != \"None\"\}

#
#  The individual objects set the \"at\" output value.
#
Setup \{set at \"\"\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Calculus-5/Slices/Level {
  {#
#  We make a plane via a polyhedron (single
#  rectangular face at the right height).
#

Faces \{
  \{(-1,-b,h) (-1,b,h) (1,b,h) (1,-b,h)\}
\}

ShowMe \{slice == \"Level\"\}

#
#  We set the height based on the slider value
#  and set the \"at\" variable for display.
#
Setup \{
  let h = 2k -1
  set at [format \"height %.3g\" $h]
\}}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-5/Slices/Line {
  {#
#  For a slice along a line through the origin,
#  we set the angle based on the slider and
#  then compute the direction vector.
#
Setup \{
  let t = k pi
  let u = (cos t, sin t)
  set at [format \"angle %.3g\" $t]
\}

ShowMe \{slice == \"y=mx\"\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Calculus-5/Slices/Line/Curve {
  {#
#  We compute the slice curve parametrically.
#  The t^3 is so that we get more divisions
#  near the origin, where we need them.
#
Domain \{-1 1 35\}

Function \{t\} \{
  let (x,y) = t^3 u
  let z = 2 x^2 y / (x^4 + y^2)
\}}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Polyhedron Create Calculus-5/Slices/Line/Plane {
  {#
#  The slice plane is given by a rectangle using
#  the direction vector.
#

Faces \{
  \{u::-1 u::1 (-u)::1 (-u)::-1\}
\}}
  {always 1 each}
  {{ list 1 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Calculus-5/Slices/Trace {
  {#
#  We get the correct x value based on the
#  slider, and set the \"at\" value for display.
#

Setup \{
  let xx = 2k - 1
  set at [format \"x = %.3g\" $xx]
\}

ShowMe \{slice == \"yz-Trace\"\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Calculus-5/Slices/Trace/Curve {
  {#
#  We compute the x and y and then use these
#  to get z.  The t^5 is so that we have greater
#  resolution at the origin, where we need it.
#

Domain \{-1 1 35\}

Function \{t\} \{
  let (x,y) = (xx,t^5 b)
  let z = 2 x^2 y / (x^4 + y^2)
\}}
  {always 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Polyhedron Create Calculus-5/Slices/Trace/Plane {
  {#
#  Again, the slice plane is given by a rectangle.
#

Faces \{
 \{(xx,-b,-1) (xx,-b,1) (xx,b,1) (xx,b,-1)\}
\}}
  {always 1 each}
  {{ list 1 0.47843137 0.47843137} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Calculus-5/Surface {
  {#
#  This is the graph of the function.  Note that it
#  is reparameterized in order to display it better.
#  We break the domain into three parts:  the part
#  where -a < u < a is mapped to the region between
#  the two parabolas, while a < u < 1 is mapped to
#  the area above the positive parabola, and 
#  similarly, -1 < u < a is mapped to the region
#  below the negative one.
#
#  We avoid t = 0 by moving to the side slightly.
#  We also use x = t |t| (signed version of t^2)
#  to get more resolution near the origin.
#

Domain \{\{-1 1 21\} \{-1 1 31\}\}

Function \{t u\} \{
  if \{$t == 0\} \{set t .0001\}

  let x = abs(t) t
  if \{$u < -$a\} \{
    let uu = (u+1) / (1-a)
    let y = -(uu x^2 + (1-uu) b)
  \} elseif \{$u > $a\} \{
    let uu = (u-a) / (1-a)
    let y = uu b + (1-uu) x^2
  \} else \{
    let y = u x^2 / a
  \}

  let z = 2 x^2 y / (x^4 + y^2)
\}

CheckBox show 1 -title \"Show Surface\" \\
  -in cbox -at \{1 0\}
ShowMe show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}
