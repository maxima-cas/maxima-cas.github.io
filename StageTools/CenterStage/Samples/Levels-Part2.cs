#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/LevelsPart2.cs
#  Created:  Fri Nov 12 10:27:11 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Levels-8 {
  {#
#  This example shows a surface and a series of
#  level curves for that surface.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-8/Levels {
  {#
#  We get ten levels between .1 and .9 where 
#  the highest hight is normalized to be 1 and
#  the lowest to be 0.
#

Height z at [Points \{.1 .9\} 10] -normalize
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::DataFromSurface Create Levels-8/Surface {
  {#
#  Note that we use a link to the surface rather
#  than a separate surface object itself (via
#  a DataFromSurface object).  This means we
#  don't have to recompute the surface for each
#  new example, and if you want to try these
#  examples on a different surface, you just 
#  have to change one surface (the last object in
#  the list).  You could even use a TypeIn for
#  the surface's function and domain.
#
CheckBox Show 1
ShowMe Show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-9 {
  {#
#  In this example we have a surface sliced by
#  a plane.  The height of the plane is controled
#  by a slider.
#
#  Near the critical point, the representation of
#  the level set breaks down, due to the polygonal
#  approximation to the surface.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Levels-9/Level {
  {#
#  The slider controls both the slicing plane and
#  the slice.
#
Slider h -1 1}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-9/Level/Intersection {
  {#
#  We don't use \"-normalize\" here since we
#  want h to represent an absolute height
#
Height z = h
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Polyhedron Create Levels-9/Level/Plane {
  {#
#  A cheap way to get the slicing plane at the
#  right height.
#

Vertices \{
 00: (-1,-1,h)  01: (-1,1,h)
 10: (1,-1,h)   11: (1,1,h)
\}

Faces \{
  \{00 01 11 10\}
\}}
  {always 1 each}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromSurface Create Levels-9/Surface {
  {CheckBox Show 1
ShowMe Show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-10 {
  {#
#  Here we show the region near height z=0 as a
#  red band.  The rest of the surface is as
#  usual.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-10/Rest {
  {#
#  We use two different slices connected by an \"or\"
#  to get the part of the surface that is not
#  near z = 0.
#
Height z < -.05 or z > .05
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Levels Create Levels-10/Zero {
  {#
#  This is the chunk near z = 0
#
Height z within (-.05,.05)
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Group Create Levels-11 {
  {#
#  This example is like the previous one, but
#  you can use a slider to change the height of
#  the red slice.  It takes a fast computer
#  to make this worth while.
#
Slider h -1 1 0}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-11/Rest {
  {Height z < h-.05 or z > h+.05
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Levels Create Levels-11/Slice {
  {Height z within (h-.05,h+.05)
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Group Create Levels-12 {
  {#
#  Here we have a series of red slices with the
#  rest of the surface shown with its usual colors.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-12/Rest {
  {#
#  To get the main part of the surface, we use
#  the \"Bands\" command to get a list of 6 intervals
#  for the bands.  They fill 80% of the band (due
#  to the .8)
#
Height z within [Bands \{0 1\} 6 .8] -normalize
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Levels Create Levels-12/Slices {
  {#
#  For the red slices, we use the \"UnBands\" command
#  which returns a set of intervals that is the
#  opposite of the ones returned by \"Bands\".  These
#  are the intervals that are left out of the
#  corresponding \"Bands\" command.
#
Height z within [UnBands \{0 1\} 6 .8] -normalize
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::Group Create Levels-13 {
  {#
#  Here we slice a surface using a more complicated
#  height function.  Rather than using \"z\" as the
#  height, we use \"x+y\".
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-13/Levels {
  {#
#  We use \"Points\" to get 10 points spaced
#  equally between .1 and .9, then compute
#  levels for the function \"x+y\" at these
#  (normalized) heights.  This saddle surface
#  is a ruled surface, and these slices
#  give a set of rulings for the surface.
#

Height x+y at [Points \{.1 .9\} 10] -normalize

#
#  To get the colors to be constant on each slice,
#  we use a ColorFunction that returns the height
#  and color by that.
#

ColorFunction Height \{x+y\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::DataFromSurface Create Levels-13/Surface {
  {CheckBox Show 1
ShowMe Show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-14 {
  {#
#  In this example, we compute heights in an
#  arbitrary direction (given by a vector).
#  We could even make that vector be given by
#  a TypeIn.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-14/Levels {
  {#
#  We want the level sets for heights in this
#  direction.
#

let V = (1,2,3)

#
#  The dot-product of a point with the vector V
#  gives a measure of the height in that direction
#  (since we use -normalize, there is no need to
#  normalize the vector first).
#

Height (x,y,z).V at [Points \{.1 .9\} 10] -normalize

#
#  Again, we use the height function to color
#  the levels as well.
#

ColorFunction Height \{(x,y,z).V\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 1}
}

####################

::class::DataFromSurface Create Levels-14/Surface {
  {CheckBox Show 1
ShowMe Show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-15 {
  {#
#  In this example we get the level sets of a
#  surface, but project them down to the xy-plane
#  (i.e., we view them in the domain of the
#  function rather than on the graph). 
#
#  Pressing \"W\"  in the Geomview window will let
#  you see the level sets from directly above.
#

#
#  This transformation does the projection.
#
Axes \{x y z\} -> \{x y\}

#
#  This is the direction for the height function
#
let V = (1,2,3)
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-15/Levels {
  {Height (x,y,z).V at [Points \{.1 .9\} 10] -normalize
ColorFunction Height \{(x,y,z).V\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 1}
}

####################

::class::DataFromSurface Create Levels-15/Surface {
  {#
#  We change the light source for the surface
#  so that it is not so brightly light.  Normally,
#  Geomview has a bright light directly from
#  our viewpoint, and when you look at the xy-plane
#  from the z-axis, this would make the plane
#  brightly light, washing out the level sets.  We
#  adjust the lights through an OOGL \"appearance\"
#  speceification.
#
Appearance \{
  lighting \{
    ambient 0.2 0.2 0.2
    replacelights
    light \{
      color .5 .5 .5
      position 0 0 1 0.0
    \}
  \}
\}

#
#  Here, we color the surface by height in
#  the given direction as well.
#
ColorFunction Height \{(x,y,z).V\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-16 {
  {#
#  This example puts the previous examples together
#  into one view.  You get the surface in space
#  with the level sets on it plus the xy-plane
#  (colored by the surface height) together with
#  the level sets pulled back to the domain of
#  the surface.
#

let V = (1,2,3);  # the direction of slices

#
#  A function to compute the height in this
#  direction.
#
proc height \{x y z\} \{
  variable V
  let h = (x,y,z).V
  return $h
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Levels-16/Graph {
  {#
#  This group contains the surface and the levels
#  on the surface.  They are translated up so
#  that they don'e intersect the xy-plane (as this
#  makes the image hard to read).
#

let d = 1.5
Transform \{Translate(0,0,d)\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Levels-16/Graph/Borders {
  {#
#  This group contains the borders for the surface
#  and its domain, plus the vertical lines between
#  the two.
#}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Levels-16/Graph/Borders/Domain {
  {#
#  A polyhedral object is used to get the lines
#  around the domain and the ones up to the
#  surface.  The function F is defined below.
#  
Vertices \{
  00: (-1,-1,-d) f00: (-1,-1,F(-1,-1))
  01: (-1,1,-d)  f01: (-1,1,F(-1,1))
  10: (1,-1,-d)  f10: (1,-1,F(-1,1))
  11: (1,1,-d)   f11: (1,1,F(1,1))
\}

Faces \{
 \{00 01 11 10\} <- \{outline width 3\}
 \{00 f00\} \{01 f01\} \{10 f10\} \{11 f11\}
\}

#
#  This polyhedron is linked to the Surface
#  object, and so it can call the surface's
#  routines via the Object command.  The surface
#  has a function F that computes that value of
#  the surface at a particular point, so we use
#  that to get access to the surface values.
#
proc F \{x y\} \{
  let (x,y,z) = [Object F $x $y]
  return $z
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
}

####################

::class::SurfaceNewDomain Create Levels-16/Graph/Borders/Surface {
  {#
#  We want just the borders of the surface, so 
#  we use a SurfaceNewDomain object linked
#  to the surface and supply two domain 
#  components to form the edges.
#
Domain \{
  \{\{-1 1 10\} \{-1 1 1\} LinesU\}
  \{\{-1 1 1\} \{-1 1 10\} LinesV\}
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Levels Create Levels-16/Graph/Levels {
  {#
#  Here we compute the slices of the surface
#  using the given height function, and color
#  them using the same function.
#

Height height(x,y,z) at [Points \{.1 .9\} 10] -normalize
ColorFunction Height \{height(x,y,z)\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {0 1}
}

####################

::class::DataFromSurface Create Levels-16/Graph/Surface {
  {#
#  This is the surface itself.
#

ColorFunction Height \{height(x,y,z)\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-16/xy-Plane {
  {#
#  This group contains the data for the domain
#  of the function.  We use the same projection
#  techniques as in the previous example to
#  project the levels and the surface onto the
#  xy-plane.
#

Axes \{x y z\} -> \{x y\}
}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create Levels-16/xy-Plane/Levels {
  {#
#  Here we link to the levels that we already
#  computed in the group called \"Graph\".  We need
#  to recolor them since the colors are not
#  retained in a DataFromPolyhedron object.
#

ColorFunction Height \{height(x,y,z)\}}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 0}
}

####################

::class::DataFromSurface Create Levels-16/xy-Plane/Surface {
  {#
#  Again, we change the lighting so that the
#  xy-plane will not overpower the levels within
#  it (see the previous example).
#
Appearance \{
  lighting \{
    ambient 0.2 0.2 0.2
    replacelights
    light \{
      color .75 .75 .75
      position 0 0 1 0.0
    \}
  \}
\}

ColorFunction Height \{height(x,y,z)\}
}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Levels-17 {
  {#
#  In this example, we slice the surface using
#  a non-linear function.  In this case, our
#  slices are by concentric spheres at the origin.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-17/Levels {
  {#
#  Any function could be used for the height.  We
#  use the distance of the point from the origin.
#  This means we are slicing by spheres.
#

Height Norm(x,y,z) at [Points \{.1 .9\} 10] -normalize

ColorFunction Height \{Norm(x,y,z)\}}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 1}
}

####################

::class::DataFromSurface Create Levels-17/Surface {
  {CheckBox Show 1
ShowMe Show}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface {
  {#
#  This is the surface that is linked from all
#  the other examples.  It is a saddle surface,
#  but you could make the function be entered in
#  a TypeIn for a more interesting demonstration.
#
#  Try x^3 - x - y^2 as another example.
#
Domain \{\{-1 1 10\} \{-1 1 10\}\}

Function \{x y\} \{
  let z = x^2 - y^2
\}
}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {1 {}}
  {::sd::Patch 0 0 .25}
}
