#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Links-Part2.cs
#  Created:  Thu Nov 18 17:03:30 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Link-9 {
  {#
#  A saddle surface with an offset surface
#  at a distance specified by a slider.  This
#  takes a while to compute, so be patient.
#
#  Notice how the offset surface turns itself
#  inside out at the distance increases (so that
#  the colors appear in the reverse order).
#  This is because the surface is negatively
#  curved.
#}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::OffsetSurface Create Link-9/Offset {
  {Domain Inherit

Offset d

Slider d 0 2 .9 -title \"Offset distance:\" -simpletitle
}
  {always 1 keep}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {{} 4}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Link-9/Original {
  {Domain \{
  \{\{0.001 1 6\} \{-pi pi 24\}\}
  \{\{1 1 1\} \{-pi pi 24\} LinesV \{0 0 0\}\}
\}

Function \{r t\} \{
  let (x,y) = (r cos t, r sin t)
  let z = x^2 - y^2
\}}
  {always 1 keep}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {4 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Link-10 {
  {#
#  Here we have the same saddle surface and offset
#  surface, but this time we link the two by lines
#  normal to the original surface along its
#  boundary (we could do normals throughout the
#  original surface, but the result is not easy
#  to read).  This gives a better idea of the
#  connection between the offset and the original
#  by showing where some of the points on the
#  offset come from on the original surface.
#
#  We create the normals using a curve on the 
#  surface together with a surface over that.
#  The surface is built in the surface-frame
#  of the boundary curve (i.e., we have access
#  to the surface's normal vector) and we
#  render the surface as lines (to get the effect
#  of normal lines).
#}
  {selected 1 keep}
  {{set z} 1 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}

####################

::class::CurveOnSurface Create Link-10/Boundary {
  {#
#  This curve simply runs around the boundary.
#  It is not actually shown, but is used only
#  for constructing the normal lines
#

Domain \{-pi pi 24\}

Function \{v\} \{
  let (r,theta) = (1,v)
\}

Axes \{r theta z\}}
  {hide 1 keep}
  {{set theta} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {0 5}
  {::cd::Solid}
}

####################

::class::Group Create Link-10/Offset {
  {#
#  We put the slider here in a group so that
#  it will be available to both objects, and
#  so that chances to it will only effect
#  those two.
#
Slider d 0 2 .9
}
  {always 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::SurfaceFromCurve Create Link-10/Offset/Normals {
  {#
#  Use the boundary curve's surface frame and
#  place the surface in the direction of the normal
#  vector.  Use Lines int he s direction to get
#  the effect of normal lines.  The domain has
#  s run from 0 to d so that they are the correct
#  length.
#
Domain \{\{0 d 1\} Inherit\}

Function \{s\} \{
  let (N,U,V) = (s,0,0)
\} -sframe

Axes \{N U V\}}
  {always 1 keep}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
  {::sd::LinesU 0 0 .25}
}

####################

::class::OffsetSurface Create Link-10/Offset/Surface {
  {Domain Inherit

Offset d
}
  {always 1 keep}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {{} 5}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Link-10/Original {
  {#
#  A saddle surface with a black boarder.
#

Domain \{
  \{\{0.001 1 6\} \{-pi pi 24\}\}
  \{\{1 1 1\} \{-pi pi 24\} LinesV \{0 0 0\}\}
\}

Function \{r t\} \{
  let (x,y) = (r cos t, r sin t)
  let z = x^2 - y^2
\}}
  {always 1 keep}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {5 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Link-11 {
  {#
#  This example shows a surface (torus) together
#  with a curve on that surface.  The curve is
#  a (p,q)-curve on the torus (one that goes
#  p times around it one direction and q times
#  around the other direction.
#}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Link-11/Knot {
  {#
#  This is a (p,q)-curve on the torus
#  (it goes around one dircetion p times
#  the other direction q times).
#

#
#  The number of divisions to use is
#  determined by the size of p and q
#

Domain \{-pi pi Max(32,12(p+q))\}

Function \{t\} \{
  let (x,y) = (p t,q t)
\}

Slider p 0 5 1 -resolution 1
Slider q 0 5 0 -resolution 1}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {{} 6}
  {::cd::Solid}
}

####################

::class::Surface Create Link-11/Torus {
  {Domain \{\{-pi pi 12\} \{-pi pi 24\}\}

Function \{u v\} \{
  let (x,y,z) = (\\
    (a + b cos(u)) cos(v), \\
    (a + b cos(u)) sin(v),\\
    b sin(u) \\
  )
\}

#
#  The radii of the circles that form
#  the torus
#

Slider a 0 3 sqrt(2)
Slider b 0 3 1}
  {always 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {6 {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Link-12 {
  {#
#  This example shows a surface (torus) together
#  with a curve on that surface.  The curve is
#  a (p,q)-curve on the torus (one that goes
#  p times around it one direction and q times
#  around the other direction.
#
#  In this case, we make the curve in the class
#  CurveFromSurface (rather than CurveOnSurface)
#  so that we can raise it off the surface a
#  little bit.  This can avoid some difficulties
#  where the curve seems to cut through the
#  surface (due to differences in the resolution
#  of their parameterizations).  It is slower,
#  however.
#}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveFromSurface Create Link-12/Knot {
  {Domain \{-pi pi Max(32,12(p+q))\}

Function \{t\} \{
  let (x,y) = (p t,q t)
\} \{
  let (x,y,z) = (-.025,0,0)
\} -frame

Slider p 0 5 1 -resolution 1
Slider q 0 5 0 -resolution 1}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {{} 7}
  {::cd::Solid}
}

####################

::class::Surface Create Link-12/Torus {
  {Domain \{\{-pi pi 12\} \{-pi pi 24\}\}

Function \{u v\} \{
  let (x,y,z) = (\\
    (a + b cos(u)) cos(v), \\
    (a + b cos(u)) sin(v),\\
    b sin(u) \\
  )
\}

#
#  The radii of the circles that form
#  the torus
#

Slider a 0 3 sqrt(2)
Slider b 0 3 1}
  {always 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {7 {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Link-13 {
  {#
#  This example shows a curve on a surface.
#  Checkboxes allow you to view either the
#  normal vectors to the surface (along the curve)
#  or the binormal vecors to the curve as a space
#  curve.  Note that these vectors rarely point
#  in the same direction, indicating that the
#  Frenet frame is not the same as the natural
#  frame for surface itself.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveVectors Create Link-13/CurveBinormals {
  {Domain Inherit

ArrowScale .75
ArrowHead .3 .03 -outline

CheckBox Show 0
ShowMe Show}
  {always 1 each}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
  {0 0 1 0 0 0 0 0 1}
}

####################

::class::CurveOnSurface Create Link-13/CurveOnSurface {
  {Domain \{-pi pi 32\}

Function \{t\} \{
  let (x,y) = (cos(t),sin(t))
\}}
  {always 1 each}
  {{ list 1 0 0} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {1 8}
  {::cd::Solid}
}

####################

::class::Surface Create Link-13/Surface {
  {Domain \{\{-1.2 1.2 10\} \{-1.2 1.2 10\}\}

Function \{u v\} \{
  let (x,y,z) = (u, v, u v)
\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {8 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::CurveVectors Create Link-13/SurfaceNormals {
  {Domain Inherit

ArrowScale .75
ArrowHead .3 .03 -outline

CheckBox Show 0
ShowMe Show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {constant 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
  {0 0 0 0 0 1 0 0 1}
}

####################

::class::Group Create Link-14 {
  {#
#  This is the tangent developable surface
#  (the surface formed by taking the collection
#  of tangent lines to a curve).  In this case
#  the curve is a helix (show at the center in
#  bright colors).  The coloring of the curve
#  and surface are coordinated.
#
#  Note that every point on the curve is a
#  singular point for the surface.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-14/Curve {
  {Domain \{-2pi 2pi 48\}

Function \{t\} \{
  let (x,y,z) = (cos t, sin t, t/2)
\}}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {2 {}}
  {::cd::Solid}
}

####################

::class::SurfaceFromCurve Create Link-14/Tangent {
  {Domain \{\{-3 3 8\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (s,0,0)
\} -frame

Axes \{T N B\}}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 2}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Link-15 {
  {#
#  This is the normal developable surface
#  (the surface formed by taking the collection
#  of lines along the principle normals to a curve
#  at every point along the curve).
#
#  Here we use a helix (show in bright colors)
#  for our base curve.  Note that the normal surface
#  in this case is a helicoid.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Link-15/Curve {
  {Domain \{-2pi 2pi 48\}

Function \{t\} \{
  let (x,y,z) = (cos t, sin t, t/2)
\}}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {3 {}}
  {::cd::Solid}
}

####################

::class::SurfaceFromCurve Create Link-15/Normal {
  {Domain \{\{-1 3 6\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (0,s,0)
\} -frame

Axes \{T N B\}}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 3}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Link-16 {
  {#
#  This is the binormal developable surface
#  (the surface formed by taking the collection
#  of lines along the binormal vectors to a curve
#  at every point along the curve).
#
#  Here we use a helix (show in white) for our
#  base curve.  The binormal surface appears as
#  an \"unwinding ribbon\".  As we extend the
#  surface (by making d larger), the surface
#  begins to intersect itself (the intersection 
#  curve is another helix).  Extending even further
#  produces yet another helical intersection,
#  and so on.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::SurfaceFromCurve Create Link-16/Binormal {
  {Domain \{\{-d d Max(6,int(4d))\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (0,0,s)
\} -frame

Axes \{T N B\}

Slider d 1 5}
  {always 1 each}
  {{set t} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 9}
  {::sd::Patch 0 0 .25}
}

####################

::class::Curve Create Link-16/Curve {
  {Domain \{-2pi 2pi 48\}

Function \{t\} \{
  let (x,y,z) = (cos t, sin t, t/2)
\}}
  {always 1 each}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {9 {}}
  {::cd::Solid}
}
