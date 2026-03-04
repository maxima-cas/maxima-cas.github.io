#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/OtherSurfaces.cs
#  Created:  Fri Nov 12 10:42:14 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Surface-1 {
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

::class::Curve Create Surface-1/Curve {
  {Domain \{-pi pi 48\}

Function \{t\} \{
  let (x,y) = (sqrt(2) cos t, sin t)
\}

Axes \{x y\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {0 {}}
  {::cd::Solid}
}

####################

::class::SurfaceFromCurve Create Surface-1/Sandpile {
  {Domain \{\{0 2.5 1\} Inherit\}

Function \{s\} \{
  let (T,N,B) = (0,s,s)
\} -frame

Axes \{T N B\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 0}
  {::sd::Patch 0 1 .25}
}

####################

::class::Group Create Surface-2 {
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

::class::Curve Create Surface-2/Curve {
  {Domain \{-pi pi 24\}

Function \{t\} \{
  let (x,y) = (cos t, sin t)
\}

Axes \{x y\}}
  {selected 1 each}
  {{set y} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {1 {}}
  {::cd::Solid}
}

####################

::class::RuledSurface Create Surface-2/Hyperboloid {
  {Domain \{\{-1 1 10\} Inherit\}

Vector \{t\} \{a 0 1\} -frame

Slider a -2 2 0

Axes \{x y z\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 1 .25}
}

####################

::class::Surface Create Surface-3 {
  {#
#  Like the previous example, here we have
#  a family of ruled surfaces, this time, one
#  that includes a cylinder, a series of
#  hyperboloids and a cone.  The cylinder is
#  when a = 0, and the cone is with a at either
#  endpoint of the slider (-pi/2 or pi/2).
#
#  The slider tells how much \"twist\" to the
#  top and bottom circles (they are twisted in
#  opposite directions).
#

Domain \{\{0 1 10\} \{-pi pi 24\}\}

#
#  Here we use the \"two-function\" form
#  of the Function directive.  The second
#  is performed once for each value of u
#  and then the upper is computed for each
#  value of v.  This is more efficient than
#  computing P0 and P1 again for each v, since
#  they don't depend on v.
#
Function \{v u\} \{
  let (x,y,z) = v P1 + (1-v) P0 
\} \{
  let P0 = (cos(u-a),sin(u-a),-1)
  let P1 = (cos(u+a),sin(u+a), 1)
\}

Slider a -pi/2 pi/2 0}
  {selected 1 each}
  {{set u} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 1 .25}
}

####################

::class::SurfaceOfRevolution Create Surface-4 {
  {#
#  Again, this example relates to previous two.
#  It gives another way to do the hyperboloid -- 
#  this time as a surface of revolution.
#

Domain \{\{-pi pi 24\} \{-1 1 10\}\}

#
#  Rotate the xy-plane through the point (0,0)
#  (i.e., rotate about the z-axis)
#

Rotate \{x y\} \{0 0\}

#
#  The function is a line but not lying in
#  the xz-plane (if it did, we'd get a
#  cylinder instead).

Function \{t\} \{
  let (x,y,z) = (1,t,t)
\}
}
  {selected 1 each}
  {{set theta} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 0 .25}
}

####################

::class::SurfaceOfRevolution Create Surface-5 {
  {#
#  Here is a torus given as a surface of revolution.
#

#
#  domain for theta and t
#
Domain \{\{-pi pi 24\} \{-pi pi 12\}\}

#
#  A circle in the xz-plane of radius b centered
#  at (a,0)
#
Function \{t\} \{
  let (x,z) = (a + b cos(t), b sin(t))
\}

#
#  Rotate around the z-axis
#
Rotate \{x y\} \{0 0\}

#
#  Circle's radius and offset
#
Slider a 0 3 sqrt(2)
Slider b 0 3 1}
  {selected 1 keep}
  {{set theta} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::SurfaceOfRevolution Create Surface-6 {
  {#
#  Here is a torus given as a surface of
#  revolution.  This time, we rotate around
#  an axis that is not the z-axis.
#

#
#  domain for theta and t
#
Domain \{\{-pi pi 24\} \{-pi pi 12\}\}

#
#  A circle in the xz-plane of radius b centered
#  at the origin
#
Function \{t\} \{
  let (x,z) = (b cos(t), b sin(t))
\}

#
#  Rotate the xy-plane around the point (-a,0)
#
Rotate \{x y\} \{-a 0\}

#
#  Circle's radius and offset
#
Slider a 0 3 sqrt(2)
Slider b 0 3 1}
  {selected 1 keep}
  {{set theta} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::Surface Create Surface-7 {
  {#
#  Here is a torus that is mapped conformally
#  from the uv-plane (Note how the faces are
#  smaller in the center of the hole).  The
#  previous examples are not conformal.
#
#  It is the stereographic projection of the
#  Clifford torus on the three-sphere in
#  four-space.
#
Domain \{\{-pi pi 24\} \{-pi pi 24\}\}

Function \{u v\} \{
  let (x,y,z,w) = (cos u, sin u, cos v, sin v)
\}

Axes \{x y z w\} -> \{x y z\} -stereo sqrt(2)}
  {selected 1 each}
  {{set u} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 1 .25}
}
