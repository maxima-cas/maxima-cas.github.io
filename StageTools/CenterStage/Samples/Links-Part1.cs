#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Links.cs
#  Created:  Fri Nov 12 10:31:33 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Link-1 {
  {#
#  Offset curve attached to a slider that
#  lets you set the offset distance.
#  Note how the swallow tail forms at 
#  around d = .54
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 0 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Link-1/Axes {
  { Length 1.25

Axes \{x y\}

ArrowHead .075 .012 -outline}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-1/Curve {
  {Domain \{-1.5 1.5 24\}

Function \{x\} \{
  let y = x^2
\}

Axes \{x y\}}
  {always 1 each}
  {{set x} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {0 {}}
  {::cd::Solid}
}

####################

::class::OffsetCurve Create Link-1/OffsetCurve {
  {Domain Inherit

Offset d

Slider d 0 5 -title \"Offset distance:\" -simpletitle}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
  {::cd::Solid}
}

####################

::class::Group Create Link-2 {
  {#
#  Here we produce a series of offset
#  curves to the given curve (in white).
#  We do this using a SurfaceFromCurve
#  object that has its domain showing
#  only lines in one of its parametric
#  directions.
#
#  The cusps of the family of offet curves
#  sweeps out the evolute of the parabola.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Link-2/Axes {
  {Length 1.25

Axes \{x y\}

ArrowHead .075 .012 -outline}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-2/Curve {
  {Domain \{-1.5 1.5 24\}

Function \{x\} \{
  let y = x^2
\}

Axes \{x y\}}
  {always 1 each}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {1 {}}
  {::cd::Solid}
}

####################

::class::SurfaceFromCurve Create Link-2/OffsetCurves {
  {Domain \{\{-1 3 16\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (0,s,0)
\} -frame

Axes \{T N B\}}
  {always 1 each}
  {{set s} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::LinesV 0 0 .25}
}

####################

::class::Group Create Link-3 {
  {#
#  Here we produce a selection of normal
#  lines to the given curve.  We use the
#  same SurfaceFromCurve as before, but
#  switch to the other set of parametric
#  lines.
#
#  Here, the envelope of the noraml lines
#  forms the evolute of the original curve.
#
#  Some other interesting curve to look
#  at are:
#
#    f(t) = (2cos(t),sin(t))  (ellipse)
#    Domain: (-pi,pi,64)
#    Line Domain: (0,5)
#
#    f(t) = (n cos t + cos(n t),
#            n sin t + sin(n t))
#    (for various integer values of n)
#    Domain: (-pi,pi,64)
#    Line Domain: (0,3) (or larger)
#

proc F \{t\} \{
  variable f
  let P = ($f)
  if \{[llength $P] == 1\} \{let P = t :: P\}
  return $P
\}

TypeIn f \"(t,t^2)\" -title \"f(t) =\" -width 30
TypeIn D \"(-1.5,1.5,25)\" -evaluate -title \"Domain:\"}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Link-3/Axes {
  {Length 1.25

Axes \{x y\}

ArrowHead .075 .012 -outline}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-3/Curve {
  {Domain \{$D\}

Function \{t\} \{
  let (x,y) = F(t)
\}

Axes \{x y\}}
  {always 1 each}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {2 {}}
  {::cd::Solid}
}

####################

::class::SurfaceFromCurve Create Link-3/Lines {
  {Domain \{\{lm lM 1\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (0,s,0)
\} -frame

Axes \{T N B\}

TypeIn L \"(-1,3)\" -evaluate -title \"Line Domain:\" -simpletitle
Setup \{let (lm,lM) = L\}}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 2}
  {::sd::LinesU 0 0 .25}
}

####################

::class::Group Create Link-4 {
  {#
#  This is the sandpile surface over an
#  ellipse.  It is formed by taking the normals
#  to the ellipse and lifting them up at a
#  45 degree angle.  This surface contains
#  four swallow tails, four lines of cusps,
#  and two lines of self intersection.
#
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-4/Curve {
  {Domain \{-pi pi 48\}

Function \{t\} \{
  let (x,y) = (sqrt(2) cos t, sin t)
\}

Axes \{x y\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {3 {}}
  {::cd::Solid}
}

####################

::class::SurfaceFromCurve Create Link-4/Sandpile {
  {Domain \{\{0 2.5 1\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (0,s,s)
\} -frame

Axes \{T N B\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 3}
  {::sd::Patch 0 1 .25}
}

####################

::class::Group Create Link-5 {
  {#
#  Here is a family of hyperboloids of one
#  sheet represented as ruled surfaces.
#  The slider value controls the \"tilt\"
#  of the ruling lines.
#
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-5/Curve {
  {Domain \{-pi pi 24\}

Function \{t\} \{
  let (x,y) = (cos t, sin t)
\}

Axes \{x y\}}
  {selected 1 each}
  {{set y} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {4 {}}
  {::cd::Solid}
}

####################

::class::RuledSurface Create Link-5/Hyperboloid {
  {Domain \{\{-1 1 10\} Inherit\}

Vector \{t\} \{a 0 1\} -frame

Slider a -2 2 0

Axes \{x y z\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
  {::sd::Patch 0 1 .25}
}

####################

::class::Group Create Link-6 {
  {#
#  Here we have a space curve together with
#  a series of coordinate vectors along the
#  curve, where the vectors point in the
#  tangent, normal and binormal directions 
#  (the Frenet frame).
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Link-6/Axes {
  {Length 1.5

ArrowHead .1 .02 -outline
Axes \{x y z\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-6/Curve {
  {Domain \{-pi pi 64\}

Function \{t\} \{
  let (x,y,z) = \\
    ((1 + cos t) cos t, (1 + cos t) sin t, sin t)
\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {5 {}}
  {::cd::Solid}
}

####################

::class::CurveVectors Create Link-6/FrenetFrame {
  {Domain \{-pi pi 24\}

ArrowScale .75
ArrowHead .3 .04
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {1 1 1 0 0 0 0 0 1}
}

####################

::class::Group Create Link-7 {
  {#
#  This example is simpilar to the previous one,
#  but here we have a single Frenet frame that
#  rides around the curve in response to a slider.
#  The slider is animated so that the frame moves
#  around the curve under its own power.
#
#  We use a tube around the curve to make it more
#  easily visible as a space curve.  We also use
#  a group object for the Frenet frame so that
#  each vector can be colored independently.
#}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-7/Curve {
  {Domain \{-pi pi 64\}

Function \{t\} \{
  let (x,y,z) = \\
    ((1 + cos t) cos t, (1 + cos t) sin t, sin t)
\}}
  {hide 1 keep}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {6 {}}
  {::cd::Solid}
}

####################

::class::Group Create Link-7/FrenetFrame {
  {Window controls -columns 1 -rows \{1 1\}

Slider t 0 2pi 0 -in controls -at \{0 0\} -width 200
Animate n 48 \{Slider t\} -loop \\
  -title \"Position:\" -in controls -at \{0 1\}}
  {always 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveVectors Create Link-7/FrenetFrame/Binormal {
  {Domain \{t t 1\}

ArrowHead .2 .05 -absolute
ArrowScale .75
}
  {always 1 keep}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 6}
  {0 0 1 0 0 0 0 0 1}
}

####################

::class::CurveVectors Create Link-7/FrenetFrame/Normal {
  {Domain \{t t 1\}

ArrowHead .2 .05 -absolute
ArrowScale .75
}
  {always 1 keep}
  {{ list 0 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 6}
  {0 1 0 0 0 0 0 0 1}
}

####################

::class::CurveVectors Create Link-7/FrenetFrame/Tangent {
  {Domain \{t t 1\}

ArrowHead .2 .05 -absolute
ArrowScale 1
}
  {always 1 keep}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 6}
  {1 0 0 0 0 0 0 0 1}
}

####################

::class::Tube Create Link-7/Tube {
  {Domain \{\{-pi pi 6\} \{-pi pi 48\}\}

Radius .05

#
#  We offset the tube slightly so that
#  the Frenet frame vectors aren't inside it
#
Tube \{theta\} \{cos(theta)-.5 sin(theta)-.5\}}
  {always 1 keep}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 6}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Link-8 {
  {#
#  Here we put a spiral curve around another curve.
#  The inner curve is shown by a tube to help
#  make the spiral easier to see against it.
#}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-8/Curve {
  {Domain \{-pi pi 48\}

Function \{t\} \{
  let (x,y,z) = \\
    ((1 + cos t) cos t, (1 + cos t) sin t, sin t)
\}}
  {hide 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 8 1 0 0 0 0 0 0 0 0 1.0 other}
  {7 {}}
  {::cd::Solid}
}

####################

::class::CurveFromCurve Create Link-8/Spiral {
  {Domain \{-pi pi Max(24,n*12)\}

Function \{t\} \{
  let (T,N,B) = (0,r cos(n t),r sin(n t))
\} -frame

Axes \{T N B\}

Slider n 0 20 -resolution 1 -simpletitle \\
  -title \"Number of Spirals:\"
Slider r 0.1 1 .33 -title \"Radius of Spiral:\" -simpletitle

ColorFunction Spiral \{-t\}
}
  {always 1 each}
  {{::_color::Function Spiral} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 7}
  {::cd::Solid}
}

####################

::class::Tube Create Link-8/Tube {
  {Domain \{\{-pi pi 8\} \{Inherit\}\}

Radius .1

Tube \{theta\} \{cos(theta) sin(theta)\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 7}
  {::sd::Patch 1 1 .25}
}
