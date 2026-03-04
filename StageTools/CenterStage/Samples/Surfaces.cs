#############################
#
#  File:     /home/idol/u0/faculty/math/dpvc/tcl/doc/CenterStage/Samples/Surfaces.cs
#  Created:  Sat Oct 16 14:34:42 EDT 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Surface Create Surface-1 {
  {#
#  A sample surface that is the graph
#  of a function of the form z = f(x,y)
#

Domain \{\{-1.3 1.2 10\} \{-1.2 1.2 10\}\}

Function \{x y\} \{
  let z = x^3 - x - y^2
\}
}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-2 {
  {#
#  A sample parametric surface that is the
#  image of a function of the form 
#
#    (x,y,z) = f(u,v)
#

Domain \{\{-pi pi 24\} \{-pi/2 pi/2 12\}\}

Function \{u v\} \{
  let (x,y,z) = \\
    (cos v cos u, cos v sin u, sin v)
\}
}
  {selected 1 each}
  {{set u} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 0 .25}
}

####################

::class::Surface Create Surface-3 {
  {#
#  A parametric surface with several domain
#  patches specified
#

Domain \{
  \{\{0 pi 12\} \{0 pi/2 6\}\}
  \{\{pi 2pi 12\} \{0 -pi/2 6\}\}
\}

Function \{u v\} \{
  let (x,y,z) = \\
    (cos v cos u, cos v sin u, sin v)
\}
}
  {selected 1 each}
  {{set u} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-4 {
  {#
#  A surface with a black border line
#

Domain \{
  \{\{-1 1 10\} \{-1 1 10\}\}
  \{\{-1 1 1\} \{-1 1 10\} LinesV \{0 0 0\}\}
  \{\{-1 1 10\} \{-1 1 1\} LinesU \{0 0 0\}\}
\}

#  or use the following:
#
# Domain [::sd::Border \{-1 1 10\} \{-1 1 10\}]

Function \{x y \} \{let z = x^2 - y^2\}
}
  {selected 1 each}
  {{ list 0 1 0} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-5 {
  {#
#  A sample surface graph that gets its
#  function from a type-in.
#

TypeIn f \"x^2 - y^2\" -title \"f(x,y) = \"
TypeIn D \"\{-1 1 10\} \{-1 1 10\}\" -evaluate \\
  -title \"Domain\" -width 20

Domain \{$D\}
Function \{x y\} \{let z = ($f)\}
}
  {selected 1 each}
  {{set z} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-6 {
  {#
#  A surface with a slider
#

Domain \{\{-1.3 1.3 10\} \{-1.3 1.3 10\}\}

Function \{x y\} \{
  let z = x^3 - a x - y^2
\}

#
#  if your machine is fast enough, add -drag
#
Slider a 0 1 1}
  {selected 1 keep}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-7 {
  {#
#  A surface with an animated slider.
#

Domain \{\{-1.3 1.3 10\} \{-1.3 1.3 10\}\}

Function \{x y\} \{
  let z = x^3 - a x - y^2
\}

Slider a 0 1 1
Animate n 10 \{Slider a\} -loop -bounce}
  {selected 1 keep}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-8 {
  {#
#  A surface with a round domain.
#

Domain \{\{0.01 1 6\} \{-pi pi 48\}\}

Function \{r t\} \{
  let (x,y) = (r cos t, r sin t)
  let z = (x^3 - 3 x y^2)
\}}
  {selected 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 1 .25}
}

####################

::class::Surface Create Surface-9 {
  {#
#  A surface graph given in polar form
#  as a function of radius and theta.
#
#     z = f(r,t)
#

Domain \{\{0.01 1 6\} \{-pi pi 48\}\}

Function \{r t\} \{
  let (x,y) = (r cos t, r sin t)
  let z = r^3 sin(3 t)
\}}
  {selected 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 1 .25}
}

####################

::class::Surface Create Surface-10 {
  {#
#  A saddle surface with a slider for the
#  index of the saddle.
#

#
#  Note the domain size changes with
#  the number of ups and downs on the
#  saddle.

Setup \{let m = Max(24,16n)\}

Domain \{
  \{\{0.01 1 6\} \{-pi pi m\}\}
  \{\{0 1 1\} \{-pi pi m\} LinesV \{0 0 0\}\}
\}

Function \{r t\} \{
  let (x,y) = (r cos t, r sin t)
  let z = r^n sin(n t)
\}

Slider n 0 6 3 -resolution 1 \\
  -title \"Number of Crests:\"
}
  {selected 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::sd::Patch 0 1 .25}
}

####################

::class::Group Create Surface-11 {
  {#
#  A function graph with a heavy border
#  and an indication of the domain.
#

TypeIn f \"3 - x^2 - y^2\" -title \"f(x,y) =\"
TypeIn D \"\{-1 1 10\} \{-1 1 10\}\" -evaluate \\
  -title \"Domain:\" -width 20

#
# A function that computes the value
# of the type-in \"f\".  (Here \"variable\"
# is used to get access to the value
# of the type-in, and the function is
# in parentheses to avoid difficulties
# with vectors vs. implied multiplication.)
#
proc F \{x y\} \{
  variable f
  let z = ($f)
  return $z
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Surface-11/Boarder {
  {#
#  Get the parts of the domain specification
#
Setup \{
  let ((mx,Mx,nx),(my,My,ny)) = D
\}

Domain \{
  \{\{mx Mx 1\}  \{my My ny\} LinesV\}
  \{\{mx Mx nx\} \{my My 1\}  LinesU\}
\}

Function \{x y\} \{let z = ($f)\}
}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Polyhedron Create Surface-11/Domain {
  {#
#  Get the parts of the domain specification
#
Setup \{
  let ((mx,Mx,nx),(my,My,ny)) = D
\}


#
#  The corner of the domain in the plane
#  plus the images under F(x,y)
#

Vertices \{
 xy: (mx,my)   Xy: (Mx,my)
 xY: (mx,My)   XY: (Mx,My)

 Fxy: (mx,my,F(mx,my)) FXy: (Mx,my,F(Mx,my)) 
 FxY: (mx,My,F(mx,My)) FXY: (Mx,My,F(Mx,My)) 
\}

#
#  The base square is just an outline.
#  Add thinner vertical lines to the graph.
#
Faces \{
  \{xy Xy XY xY\} <- \{outline width 3\}
  \{\{xy Fxy\} \{Xy FXy\}
   \{xY FxY\} \{XY FXY\}\} <- \{width 1\}
\}

CheckBox show 1
ShowMe show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create Surface-11/Graph {
  {#
#  The group's domain variable is available
#
Domain \{$D\}

Function \{x y\} \{let z = ($f)\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 0 .25}
}
