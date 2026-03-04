#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Polyhedra-Part1.cs
#  Created:  Fri Nov 19 17:41:21 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Polyhedron Create Polyhedron-1 {
  {#
#  A polyhedron with a slider that
#  controls the coordinates of its vertices.
#  Negative values for the slider are interesting.
#

Vertices \{
  a0: (1,0,t)  a1: (1,0,-t)
  b0: (-1,0,t) b1: (-1,0,-t)
  c0: (t,1,0)  c1: (-t,1,0)
  d0: (t,-1,0) d1: (-t,-1,0)
  e0: (0,t,1)  e1: (0,-t,1)
  f0: (0,t,-1) f1: (0,-t,-1)

  000: (-1,-1,-1)  001: (-1,-1,1)
  010: (-1,1,-1)   011: (-1,1,1)
  100: (1,-1,-1)   101: (1,-1,1)
  110: (1,1,-1)    111: (1,1,1)
\}

Faces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}

 \{
  \{000 100 110 010\}
  \{001 101 111 011\}
  \{000 001\} \{100 101\}
  \{110 111\} \{010 011\}
 \} <- \{outline color \{0 0 0\} width 1\}
\}

Slider t -1 1 0 -drag}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Polyhedron-2 {
  {#
#  The same object as the previous example,
#  but using reflections to generate the
#  faces from a single one.
#

}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-2/BBox {
  {#
#  A cube shown as edges only
#

Vertices \{
  000: (-1,-1,-1)  001: (-1,-1,1)
  010: (-1,1,-1)   011: (-1,1,1)
  100: (1,-1,-1)   101: (1,-1,1)
  110: (1,1,-1)    111: (1,1,1)
\}

Faces \{
  \{\{000 100 110 010\}
   \{001 101 111 011\}\} <- outline
  \{000 001\} \{100 101\}
  \{110 111\} \{010 011\}
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-2/Cube-Oct {
  {#
#  The one face that will be duplicated
#  to form the complete object.
#
#  Note, however, that the colors aren't
#  chosen well, because the orientation
#  of the reflected faces are reversed.
#  The next sample fixes this.
#

Vertices \{
  (1,0,t) (t,1,0) (0,t,1)
\}

Faces \{
  \{0 1 2\}
\}

#
#  Make copies by reflecting in each
#  of the coordinates.  Eight copies all
#  together.
#

Transform \{Copy ReflectZ\} \\
          \{Copy ReflectY\} \\
          \{Copy ReflectX\}

Slider t -1 1 0 -simpletitle -drag}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Polyhedron-3 {
  {#
#  The same object as the previous example,
#  but using a more sophisticated reflection
#  transform that handles the orientation
#  so that the faces will be colored better.
#

}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-3/BBox {
  {#
#  A cube shown as edges only
#

Vertices \{
  000: (-1,-1,-1)  001: (-1,-1,1)
  010: (-1,1,-1)   011: (-1,1,1)
  100: (1,-1,-1)   101: (1,-1,1)
  110: (1,1,-1)    111: (1,1,1)
\}

Faces \{
  \{\{000 100 110 010\}
   \{001 101 111 011\}\} <- outline
  \{000 001\} \{100 101\}
  \{110 111\} \{010 011\}
\}}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-3/Cube-Oct {
  {#
#  The one face that will be duplicated
#  to form the complete object.
#

Vertices \{
  (1,0,t) (t,1,0) (0,t,1)
\}

Faces \{
  \{0 1 2\}
\}

#
#  These next three routines perform the
#  reflections on triangles.  Note that
#  the second and third vertices are
#  interchanged, so that the orientation
#  of the relfected face will be correct.
#

proc ReflectX \{f\} \{
  let ((x0,y0,z0),(x1,y1,z1),(x2,y2,z2)) = f
  let f = ((-x0,y0,z0),(-x2,y2,z2),(-x1,y1,z1))
  return $f
\}

proc ReflectY \{f\} \{
  let ((x0,y0,z0),(x1,y1,z1),(x2,y2,z2)) = f
  let f = ((x0,-y0,z0),(x2,-y2,z2),(x1,-y1,z1))
  return $f
\}

proc ReflectZ \{f\} \{
  let ((x0,y0,z0),(x1,y1,z1),(x2,y2,z2)) = f
  let f = ((x0,y0,-z0),(x2,y2,-z2),(x1,y1,-z1))
  return $f
\}

#
#  Here we use the \"fApply\" function to
#  cause our special reflection routines
#  to be used.
#

Transform \{Copy \{fApply ReflectZ\}\} \\
          \{Copy \{fApply ReflectY\}\} \\
          \{Copy \{fApply ReflectX\}\}

Slider t -1 1 0 -simpletitle -drag}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-4 {
  {#
#  An alternative method to the same example
#  as the previous ones is to generate
#  the reflected faces \"by hand\".  This
#  also lets us do the entire object without
#  a group, since we can reflect only the
#  faces we want.
#

#
#  Only the bounding box vertices are listed
#  here.  The others are computed in Setup.
#

Vertices \{
  000: (-1,-1,-1)  001: (-1,-1,1)
  010: (-1,1,-1)   011: (-1,1,1)
  100: (1,-1,-1)   101: (1,-1,1)
  110: (1,1,-1)    111: (1,1,1)
\}

Faces \{
 $Faces
 \{
  \{000 100 110 010\}
  \{001 101 111 011\}
  \{000 001\} \{100 101\}
  \{110 111\} \{010 011\}
 \} <- \{outline color \{0 0 0\} width 1\}
\}

#
#  Reflect takes a name of a proc (Axis)
#  and a list of faces and applies
#  the procedure to each vertex in the
#  each face and adds these nee faces
#  to the original list.
#
#  Here, we invert the order of the last two
#  vertices in order to keep the orientation
#  correct (it is reversed in the reflection).
#  This procedure could be made more general
#  so that it can call ANY procedure to
#  transform the vertices, and so that it
#  can handle any number of vertices (not
#  just three), but this is sufficient for
#  this example.
#
proc Reflect \{Axis Faces\} \{
  foreach face $Faces \{
    let (v0,v1,v2) = face
    let f = ($Axis v0,$Axis v2,$Axis v1)
    lappend Faces $f
  \}
  return $Faces
\}

#
#  The next three routines perform the
#  reflections in the three different
#  coordinates.  These get called by the
#  Reflect command above.
#
proc X \{x y z\} \{
  let v = (-x,y,z)
  return $v
\}

proc Y \{x y z\} \{
  let v = (x,-y,z)
  return $v
\}

proc Z \{x y z\} \{
  let v = (x,y,-z)
  return $v
\}

Slider t -1 1 0 -drag

#
#  Here we make one face and then reflect it
#  across the different coordinate planes.
#  Each reflection returns the original
#  faces plus the reflected ones, so the
#  number goes up by a factor of two each
#  time Reflect is called.
#
Setup \{
  let F = \{(1,0,t) (t,1,0) (0,t,1)\}
  set Faces \\
    [Reflect Z \\
    [Reflect Y \\
    [Reflect X [list $F]]]]
\}}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Group Create Polyhedron-5 {
  {#
#  A compund object that lets you turn
#  its parts on and off individually.
#  The \"Poly\" object is another group
#  that contains a slider to modify
#  its parts.  The \"BBox\" object is not
#  part of this object since its verticies
#  do not depend on the slider.
#

#
#  The control window and its parts
#
Window w -title \"Polyhedron\" -rows \{1 1\} -columns 1
Frame f -in w -at \{0 0 2 1\} -relief raised -bd 2 -rows \{\{0 3\} 1 1 1 1 1 \{0 3\}\}
Frame s -in w -at \{0 1 2 1\} -columns \{0 1\} -rows 1
Frame b -in f -at \{0 5\} -columns \{0 1 0\}
}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-5/BBox {
  {#
#  A cube shown as edges only
#

Vertices \{
  000: (-1,-1,-1)  001: (-1,-1,1)
  010: (-1,1,-1)   011: (-1,1,1)
  100: (1,-1,-1)   101: (1,-1,1)
  110: (1,1,-1)    111: (1,1,1)
\}

Faces \{
  \{\{000 100 110 010\}
   \{001 101 111 011\}\} <- outline
  \{000 001\} \{100 101\}
  \{110 111\} \{010 011\}
\}

CheckBox show 1 -title \"Bounding Box\" -in b -at \{0 0\}
ShowMe show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Polyhedron-5/Poly {
  {#
#  This object has a slider for the value
#  of \"t\", plus two checkboxes that control
#  how t is used.  The Setup routine
#  computes the modified t value and then
#  determines the vertices from it.  This
#  list of vertices is passed to the
#  group's children so that the list need
#  not be computed again in each of them.
#

Setup \{
  if \{$nt\} \{set tt -$t\} else \{set tt $t\}
  let Vertices = \{
    (1,0,tt)  (1,0,-tt)
    (-1,0,tt) (-1,0,-tt)
    (tt,1,0)  (-tt,1,0)
    (tt,-1,0) (-tt,-1,0)
    (0,tt,1)  (0,-tt,1)
    (0,tt,-1) (0,-tt,-1)
  \}
\}

Slider t 0 1 -in s -at \{1 0\} -width 200


let IcosT = (sqrt(5)-1)/2

Button icost -title \" Icos \" -in s -at \{0 0\} \\
  -command \{Self Slider t Set $IcosT\}

CheckBox nt 0 -title \"Negate t\" -in b -at \{3 0\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-5/Poly/Cube-Faces {
  {#
#  We get the pre-computed face list from
#  the parent group
#

Vertices \{$Vertices\}

#
#  The face list uses a variable \"outline\"
#  that determines whether to use
#  outlined or filled faces.  This
#  variable is initialized in the Setup
#  script.
#
#  

Faces \{
 \{
  \{0 1 4\} \{0 6 1\}
  \{2 3 7\} \{2 5 3\}
  \{4 5 8\} \{4 10 5\}
  \{6 7 11\} \{6 9 7\}
  \{8 9 0\} \{8 2 9\}
  \{10 11 3\} \{10 1 11\}
 \} <- \{$outline\}
\}

Frame c -in f -at \{0 2\} -columns \{0 1 0\}
CheckBox show 0 -title \"Cubical faces\" -in c -at \{0 0\}
CheckBox oline 0 -title \"outline only\" -in c -at \{3 0\}

ShowMe show

Setup \{
  if \{$oline\} \{set outline \"outline\"\} \\
    else \{set outline \"\"\}
\}

#
#  This says that the vertex list is
#  already computed and contains no labels.
#

Precomputed -vertices -vlist}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-5/Poly/Negated-Faces {
  {Vertices \{$Vertices\}

Faces \{
  \{1 5 9\} \{0 11 5\}
  \{1 8 7\} \{0 7 10\}
  \{2 4 11\} \{3 9 4\}
  \{2 10 6\} \{3 6 8\}
\}

CheckBox show 0 -title \"Negated faces\" -in f -at \{0 3\}
ShowMe show

Precomputed -vertices -vlist}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-5/Poly/Oct-Faces {
  {Vertices \{$Vertices\}

Faces \{
 \{
  \{0 4 8\} \{1 10 4\}
  \{0 9 6\} \{1 6 11\}
  \{3 5 10\} \{2 8 5\}
  \{3 11 7\} \{2 7 9\}
 \} <- \{$outline\}
\}

Frame o -in f -at \{0 0\} -columns \{0 \{1 5\} 0\}
CheckBox show 1 -title \"Octagonal faces\" -in o -at \{0 0\}
CheckBox oline 0 -title \"outline only\" -in o -at \{3 0\}

ShowMe show

Setup \{
  if \{$oline\} \{set outline \"outline\"\} \\
    else \{set outline \"\"\}
\}

Precomputed -vertices -vlist}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-5/Poly/Rectangles {
  {#
#  These are the rectangles that intersect
#  at the origin.  They are inside the
#  object if both the octahedral and cubical
#  faces are showing.
#

Vertices \{$Vertices\}

Faces \{
  \{0 1 3 2\} \{4 5 7 6\} \{8 9 11 10\}
\}

CheckBox show 0 -title \"Central rectangles\" -in f -at \{0 4\}
ShowMe show

Precomputed -vertices -vlist}
  {always 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-6 {
  {#
#  A polyhedron with a slider that
#  controls the coordinates of its vertices,
#  and with checkboxes to add and remove
#  various parts of the object.
#
#  This is similar to the previous example
#  but does all the work in one Polyhedron
#  object rather than using groups.
#

Vertices \{
  a0: (1,0,tt)  a1: (1,0,-tt)
  b0: (-1,0,tt) b1: (-1,0,-tt)
  c0: (tt,1,0)  c1: (-tt,1,0)
  d0: (tt,-1,0) d1: (-tt,-1,0)
  e0: (0,tt,1)  e1: (0,-tt,1)
  f0: (0,tt,-1) f1: (0,-tt,-1)

  000: (-1,-1,-1)  001: (-1,-1,1)
  010: (-1,1,-1)   011: (-1,1,1)
  100: (1,-1,-1)   101: (1,-1,1)
  110: (1,1,-1)    111: (1,1,1)
\}

#
#  List the faces needed for the different
#  parts that can be turned on and off
#

set OctFaces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}
\}

set NegOctFaces \{
 \{a1 c1 e1\} \{a0 f1 c1\}
 \{a1 e0 d1\} \{a0 d1 f0\}
 \{b0 c0 f1\} \{b1 e1 c0\}
 \{b0 f0 d0\} \{b1 d0 e0\}
\}

set CubeFaces \{
 \{a0 a1 c0\} \{a0 d0 a1\}
 \{b0 b1 d1\} \{b0 c1 b1\}
 \{c0 c1 e0\} \{c0 f0 c1\}
 \{d0 d1 f1\} \{d0 e1 d1\}
 \{e0 e1 a0\} \{e0 b0 e1\}
 \{f0 f1 b1\} \{f0 a1 f1\}
\}

set RectFaces \{
 \{a0 a1 b1 b0\}
 \{c0 c1 d1 d0\}
 \{e0 e1 f1 f0\}
\}

set BBox \{
  \{\{000 100 110 010\}
   \{001 101 111 011\}\} <- outline
  \{000 001\} \{100 101\}
  \{110 111\} \{010 011\}
\}

#
#  Here the face list is created on the fly
#  when the object is recomputed.  The \"eval\"
#  statement evaluates the script and uses
#  its return value for the face list.  This
#  is returned by the \"set F\" command at the
#  end since the return value of the script
#  is the resturn value of its last command
#

Faces \{[eval \{
  set F \{\}
  if \{$showOct\} \{
   if \{$showOLines\} \\
    \{lappend F $OctFaces <- outline\} else \\
    \{append F \" \" $OctFaces\}
  \}
  if \{$showCube\} \{
   if \{$showCLines\} \\
    \{lappend F $CubeFaces <- outline\} else \\
    \{append F \" \" $CubeFaces\}
  \}
  if \{$showRect\} \{append F \" \" $RectFaces\}
  if \{$showNeg\} \{append F \" \" $NegOctFaces\}
  if \{$showBBox\} \\
   \{lappend F $BBox <- \{width 1 color \{0 0 0\}\}\}
  set F
\}]\}

Window w -title \"Polyhedron\" -rows \{1 1\} -columns 1
Frame f -in w -at \{0 0 2 1\} -relief raised -bd 2 -rows \{\{0 3\} 1 1 1 1 1 \{0 3\}\}
Frame s -in w -at \{0 1 2 1\} -columns \{0 1\} -rows 1
Frame o -in f -at \{0 0\} -columns \{0 \{1 5\} 0\}
Frame c -in f -at \{0 2\} -columns \{0 1 0\}
Frame b -in f -at \{0 5\} -columns \{0 1 0\}

Slider t 0 1 -in s -at \{1 0\} -width 200


CheckBox showOct    1 -title \"Octahedral faces\" -in o -at \{0 0\}
CheckBox showOLines 0 -title \"outlines only\" -in o -at \{2 0\}
CheckBox showCube   0 -title \"Cubical faces\" -in c -at \{0 0\}
CheckBox showCLines 0 -title \"outlines only\" -in c -at \{2 0\}
CheckBox showNeg    0 -title \"Negative faces\" -in f -at \{0 3\}
CheckBox showRect   0 -title \"Central rectangles\" -in f -at \{0 4\}
CheckBox showBBox   1 -title \"Bounding box\" -in b -at \{0 0\}
CheckBox nt         0 -title \"Negate t\" -in b -at \{2 0\}

let IcosT = (sqrt(5) - 1) / 2
Button icost -title \" Icos \" -in s -at \{0 0\} \\
  -command \{Self Slider t Set $IcosT\}

#
#  Negate the t value, if necessary
#

Setup \{if \{$nt\} \{set tt -$t\} else \{set tt $t\}\}}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}
