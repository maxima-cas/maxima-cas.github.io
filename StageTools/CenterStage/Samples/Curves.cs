#############################
#
#  File:     /home/idol/u0/faculty/math/dpvc/tcl/doc/CenterStage/Samples/Curves.cs
#  Created:  Thu Oct 07 14:08:27 EDT 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Curve Create Curve-1 {
  {#
#  The graph of a function (in 2D)
#

Domain \{-1.5 1.5 24\}

Function \{x\} \{
  let y = x^3 - x
\}

Axes \{x y\}}
  {selected 1 each}
  {{set x} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Curve Create Curve-2 {
  {#
#  A parametric curve in 2D
#

Domain \{0 4pi 100\}

Function \{t\} \{
  let (x,y) = (t cos t, t sin t)
\}

Axes \{x y\}}
  {selected 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Curve-3 {
  {#
#  The graph of a function (in 2D)
#  together with axes
#

Axes \{x y\}
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Curve-3/Axes {
  {Length 2
ArrowHead -outline

#  \"Axes\" directive is inherited from group}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Curve-3/Graph {
  {Domain \{-1.5 1.5 24\}

Function \{x\} \{
  let y = x^3 - x
\}
}
  {always 1 each}
  {{set x} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Curve-4 {
  {#
#  A parametric curve in 2D with axes
#

Axes \{x y\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Curve-4/Axes {
  {Length 15
ArrowHead .05 .015 -outline

# \"Axes\" directive is inherited from group}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Curve-4/Curve {
  {Domain \{0 4pi 100\}

Function \{t\} \{
  let (x,y) = (t cos t, t sin t)
\}
}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Curve-5 {
  {#
#  A parametric curve in 3D with axes
#

}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Curve-5/Axes {
  {#
#  Each axis is sized independently
#
Length \{1.5 1.5 5\}
ArrowHead .3 .05 -outline -absolute}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Curve-5/Curve {
  {Domain \{-4 4 100\}

Function \{t\} \{
  let (x,y,z) = (cos(pi t), sin(pi t), t)
\}
}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Curve-6 {
  {#
#  The graph of a function (in 2D)
#  together with axes and a slider
#

Axes \{x y\}
}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Curve-6/Axes {
  {Length 2
ArrowHead -outline

#  \"Axes\" directive is inherited from group}
  {always 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Curve-6/Graph {
  {Domain \{-1.5 1.5 24\}

Function \{x\} \{
  let y = x^3 - a x
\}

Slider a 0 2 1 -drag}
  {always 1 keep}
  {{set y} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Curve-7 {
  {#
#  A parametric curve in polar coordinates
#

Axes \{x y\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Curve-7/Axes {
  {Length 1.25
ArrowHead .05 .015 -outline

# \"Axes\" directive is inherited from group}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Curve-7/Curve {
  {#
#  The domain range and divisions are
#  determined by the number of leaves
#  in the rose
#
Domain \{0 m d\}

Function \{t\} \{
  let r = cos(n t)
  let (x,y) = (r cos t, r sin t)
\}

Slider n 0 6 3 -resolution 1

#
#  For even numbers of petals, we need
#  to run to 2pi with twice as many divisions
#  (since there are twice as many leaves)
#
Setup \{
  if \{$n % 2 == 0\} \{
    let m = 2pi
    let d = Max(32n,32)
  \} else \{
    let m = pi
    let d = Max(16n,32)
  \}
\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}

####################

::class::Group Create Curve-8 {
  {#
#  The graph of a function selected
#  by a menu
#

Axes \{x y\}
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Axes Create Curve-8/Axes {
  {Length 2
ArrowHead -outline

#  \"Axes\" directive is inherited from group}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Curve-8/Graph {
  {Domain \{-1.7 1.7 50\}

Function \{x\} \{
  let y = ($f)
\}

PopUp f \{Parabola Cubic Sine Cosine\} \\
  -values \{x^2 x^3 \{sin(pi x)\} \{cos(pi x)\}\} \\
  -title \"Function:\" -simpletitle}
  {always 1 each}
  {{set x} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::cd::Solid}
}
