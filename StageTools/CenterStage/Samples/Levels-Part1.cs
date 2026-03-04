#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Levels-Part1.cs
#  Created:  Fri Nov 19 17:27:22 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Slice-1 {
  {#
#  Select one of the objects named \"Level-n\" for 
#  some number n and press \"Update\" to see it.
#
#  To see the polyhedron being sliced, select
#  the \"Show Polyhedron\" button.  The percentage
#  slider controls how much of the faces of the
#  polyhedron you will see (use a small percentage
#  to show the polyhedron as a set of edges with
#  just a little of each faces showing).
#

#
#  This is the main window used by all the objects
#
Window controls -rows \{1 1\} -columns 1
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Slice-1/Levels {
  {#
#  Select one of the objects contained in this
#  one and press \"Update\" to see it.
#

#
#  These are available to all the objects.
#

Slider h 0 1 .5 -in controls -at \{0 0\} -width 200
Animate n 25 \{Slider h\} -in controls -at \{0 1\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Slice-1/Levels/Levels-1 {
  {#
#  This computes a level set of the polyhedron
#  at the height given by the slider.  Note that
#  The levels are normalized to between 0 and 1,
#  so you don't need to know the exact range of
#  heights.
#

Height z = h -normalize

#
#  Use the \"Show Polyhedron\" button to see the 
#  object along with its slice.
#
#  Use the animator to see a series of slices.
#}
  {selected 1 each}
  {{ list 1 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Slice-1/Levels/Levels-2 {
  {#
#  Here we compute a chunk of the polyhedron:
#  Everything below a certain height.
#

Height z < h -normalize

#
#  (You probably don't want the polyehdron showing
#  for this one, or if you do, use a small
#  percentage of the faces).
#
}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 1 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Slice-1/Levels/Levels-3 {
  {#
#  Here we compute a chunk of the object between
#  two values.  The thickness of the slice is
#  given by the value of \"a\" below, and the 
#  heights for the endpoints of the chunk are
#  adjusted so that the top and bottom slices
#  are also of height \"a\". (Had we used (h-a,h+a)
#  for the slice, the top and bottom slices would
#  have been half as high; try it!)
#

Height z within ((1-a)h,(1-a)h+a) -normalize

let a = .1; # the amount to use for the slice}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 1 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Slice-1/Levels/Levels-4 {
  {#
#  Here we combine two slices to make the
#  same chunk we had in the previous example.
#  You can combine as many slices as you want
#  using \"and\" or \"or\".  You can also give
#  several Height commands, in which case
#  \"or\" is assumed between them.
#

Height z > h1 -normalize and z < h2 -normalize

let a = .1; # the amount to use for the slice

#
#  The normalization for the second chop is done
#  in terms of what is left after the first cut.
#  So we need to adjust for that.
#
Setup \{
  let h1 = h(1-a)
  let h2 = a/(1-h1)
\}}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 1 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Slice-1/Levels/Levels-5 {
  {#
#  This time we use an \"or\" to get the complement
#  of the slice that we had in the previous two
#  examples.
#

Height z < (1-a)h -normalize or \\
       z > (1-a)h+a -normalize

let a = .1; # the amount to use for the missing slice
}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 1 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Slice-1/Levels/Levels-6 {
  {#
#  Here we get a collection of level sets, one
#  at each height listed in the list.  Any number
#  of levels are allowed.  To get no levels, use
#  \{\"\"\} for the list.
#

Height z at \{.1 .25 .33 .5 .67 .75 .9\} -normalize
}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 1 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Levels Create Slice-1/Levels/Levels-7 {
  {#
#  Here we use the built-in commands \"Bands\" and
#  \"Points\" to get lists of values.  Bands produces
#  a list of pairs that that divide the given
#  interval into the specified number of slices
#  (in this case we get 6 slices between 0 and 1).
#  Points gives a list of points equally spaced
#  within the interval
#
#  In this example, we get 6 bands with colored
#  borders formed by the level sets produced in
#  the second Height directive.  Note that there
#  are 12 levels since each band has a top and a
#  bottom edge.
#

Height z within [Bands \{0 1\} 6] -normalize
Height z at [Points \{0 1\} 12] -normalize

#
#  To get bands with a different width, use:
#
#    set w .25; # width of bands
#    Height z at [Bands \{0 1\} 6 $w] -normalize
#    Height z at [join [Bands \{0 1\} 6 $w]] -normalize
#
#  This takes advantage of an optional parameter
#  to \"Bands\" that says what percentage of the
#  band should be solid; the default is .5, or 50%.
#
#
}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 0}
}

####################

::class::Group Create Slice-1/Polyhedron {
  {let Vertices = \{
 (-.5,0,0) (1,-1,1) (-1,1,1)
 (-1,-1,-1) (1,1,-1)
 (0,-.25,.75) (0,.25,-.75)
\}

set Faces \{
 \{0 1 6\} \{0 6 2\}
 \{0 2 4\} \{0 4 5\}
 \{0 5 3\} \{0 3 1\}
 \{5 2 3\} \{3 2 6\}
 \{1 5 6\} \{6 5 4\}
 \{1 2 5\} \{4 3 6\}
 \{1 4 2\} \{4 1 3\}
\}

set Edges \{
  \{0 1\} \{0 2\} \{0 3\} \{0 4\} \{0 5\} \{0 6\}
  \{1 2\} \{1 3\} \{1 4\} \{1 5\} \{1 6\}
  \{2 3\} \{2 4\} \{2 5\} \{2 6\}
  \{3 4\} \{3 5\} \{3 6\}
  \{4 5\} \{4 6\}
  \{5 6\}
\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Slice-1/Polyhedron/Complete {
  {Vertices \{
 (-.5,0,0) (1,-1,1) (-1,1,1)
 (-1,-1,-1) (1,1,-1)
 (0,-.25,.75) (0,.25,-.75)
\}

Faces \{
 \{0 1 6\} \{0 6 2\}
 \{0 2 4\} \{0 4 5\}
 \{0 5 3\} \{0 3 1\}
 \{5 2 3\} \{3 2 6\}
 \{1 5 6\} \{6 5 4\}
 \{1 2 5\} \{4 3 6\}
 \{1 4 2\} \{4 1 3\}
\}
}
  {hide 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {0 {}}
}

####################

::class::Group Create Slice-1/Polyhedron/Partial {
  {Frame cb -in controls -at \{0 3\} \\
  -relief raised -bd 2 -bg grey70
CheckBox show 0 -title \"Show Polyhedron\" \\
  -in cb -at \{0 0\} \\
  -command \{
    if \{$show\} \{[Self]/Faces Slider t Enable\} \\
      else \{[Self]/Faces Slider t Disable\}
    Update
  \}

ShowMe show}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Slice-1/Polyhedron/Partial/Edges {
  {Vertices $Vertices
Precomputed -vlist -vertices
Faces $Edges
}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Slice-1/Polyhedron/Partial/Faces {
  {Vertices $Vertices
Faces $Faces
Precomputed -vlist -vertices

proc Outline \{faces \{t .2\}\} \{
  if \{$t == 1\} \{return $faces\}
  if \{$t == 0\} \{return \{\}\}
  set flist \{\}
  foreach face $faces \{
    let (p_0,p_1,p_2) = face@0
    let P = (p_0 + p_1 + p_2) / 3
    foreach i \{0 1 2\} \{let q_i = p_i + t (P - p_i)\}
    foreach i \{0 1 2\} \{
      let j = (i+1) % 3
      let f = (p_i,p_j,q_j,q_i)
      lappend flist [lreplace $face 0 0 $f]
    \}
  \}
  return $flist
\}

Slider t 0 1 1 -title \"Percentage of faces:\" \\
  -in controls -at \{0 4\} -bg grey70 -width 200 \\
  -disabled

Transform \{lApply Outline t\}
}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}
