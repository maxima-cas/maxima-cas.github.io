#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/4D.cs
#  Created:  Fri Nov 19 15:58:58 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Surface Create 1_Clifford_Torus {
  {#
#  This is the Clifford torus projected, a flat
#  torus on the three-sphere in four space,
#  projected to three-space stereographically.
#  The projection point is on the three-sphere
#  itself, so as the torus rotates through this
#  projection point, the torus appears to stretch
#  out to infinity and turn ifself inside out. 
#  This occurs betweeh steps 12 and 13.  If you 
#  switch the domain to Bands/v, this can make
#  it easier to see the interior details as the
#  torus turns inside out.
#

Domain \{\{-pi pi 24\} \{-pi pi 24\}\}

#
#  The function gives results in four-space
#
Function \{u v\} \{
  let (x,y,z,w) = (cos u, sin u, cos v, sin v)
\}


Window controls -columns 1
Slider t 0 pi/2 -title \"x-w rotation:\" \\
  -in controls -at \{0 0\} -width 200
Animate n 25 \{Slider t\} -title \"Rotation Steps:\" \\
  -in controls -at \{0 1\}

#
#  This tansformation occurs in four-space
#
Transform XW(t)

#
#  Here we define the four axes and the projection
#  that will occur.  If you want to use Geomview's
#  n-D mode for viewing, remove \"-stereo sqrt(2)\"
#  and CenerStage will switch to n-D mode
#  automatically.
#
Axes \{x y z w\} -stereo sqrt(2)}
  {selected 1 keep}
  {{set u} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create 2_Hypercube {
  {#
#  This demo lets you investigate the hypercube
#  projected orthographically into three-space
#  The three sliders allow you to rotate the
#  cube in four dimensions.
#
#  Initially you will see a multiply-covered cube
#  (two of the eight cubes project into the same
#  cube in three-space, and the remaining six
#  project to the six faces of the three-
#  dimensional cube).  This is the view of the
#  hypercube looking straight at one of its
#  cubical faces in four-space.
#
#  Each slider opens up two of the flattened
#  cubes, and corresponds to a rotation in four-
#  space.  Sliding the first one to the right
#  causes the\"sliding cubes\" illusion, opening up
#  two more of the six squashed cubes.  The view 
#  when it is all the way to the right corresponds
#  to looking directly at a square face of the
#  hypercube in four-space.
#
#  Moving the second slider to the right opens a
#  second set of cubes.  All the way to the right
#  corresponds to a view directly at an edge of the
#  hypercube.  Six cubes are opened up and arranged
#  symmetrically about the central edge (it is the
#  image of both the closest and farthest edge to
#  our point of sight).  Cubes 1 and 2 are still
#  flattened out as hexagons at the two ends of the
#  hexagonal prism.
#
#  Finally, moving the third slider opens up the
#  last pair of cubes and wecan see all eight if
#  we look carefully.  With the slider all the way
#  to the right, we have the view of the hypercube
#  looking directly at one of its corners along
#  its long diagonal.  (The farthest and closest
#  corners both appear at the center of the image.)
#
#  Setting all the sliders at .8 gives a nice view
#  of the hypercube.
#
#  Initially, we only show the frames for four of
#  the eight cubes.  You can add or remove cubes
#  using the \"Show Cubes\" type-in area.  Turn on 
#  the edges checkbox if you want to see only one
#  or two cubes at a time.
#
#  Since every face borders on two cubes, if you
#  include all the cubes, every face will be
#  multiply covered.  This can make it hard to see
#  what is what.  You can use the \"Shrink\" typein
#  to shrink each cube toward its center so that
#  the faces tend to separate (this does not always
#  occur, depending on the projection).
#
#  The \"Frame Width\" type-in controls the thickness
#  of the colored faces representing each cube.
#  
set Vertices \{
  \{-1 -1 -1 -1\} \{1 -1 -1 -1\} \{-1 1 -1 -1\} \{1 1 -1 -1\}
  \{-1 -1 1 -1\} \{1 -1 1 -1\} \{-1 1 1 -1\} \{1 1 1 -1\}
  \{-1 -1 -1 1\} \{1 -1 -1 1\} \{-1 1 -1 1\} \{1 1 -1 1\}
  \{-1 -1 1 1\} \{1 -1 1 1\} \{-1 1 1 1\} \{1 1 1 1\}
\}

set Edges \{
  \{0 1\} \{2 3\} \{4 5\} \{6 7\}
  \{8 9\} \{10 11\} \{12 13\} \{14 15\}
  \{0 2\} \{1 3\} \{4 6\} \{5 7\}
  \{8 10\} \{9 11\} \{12 14\} \{13 15\}
  \{0 4\} \{1 5\} \{2 6\} \{3 7\}
  \{8 12\} \{9 13\} \{10 14\} \{11 15\}
  \{0 8\} \{1 9\} \{2 10\} \{3 11\}
  \{4 12\} \{5 13\} \{6 14\} \{7 15\}
\}

set Faces \{
  \{0 1 3 2\} \{4 6 7 5\}
  \{0 4 5 1\} \{0 2 6 4\}
  \{1 5 7 3\} \{2 3 7 6\}

  \{8 9 11 10\} \{12 14 15 13\}
  \{8 12 13 9\} \{8 10 14 12\}
  \{9 13 15 11\} \{10 11 15 14\}

  \{0 2 10 8\} \{1 3 11 9\}
  \{4 6 14 12\} \{5 7 15 13\}

  \{0 1 9 8\} \{2 3 11 10\}
  \{4 5 13 12\} \{6 7 15 14\}

  \{0 4 12 8\} \{1 5 13 9\}
  \{2 6 14 10\} \{3 7 15 11\}
\}

set Cubes \{
  \{0 1 2 3 4 5\}
  \{0 6 16 17 12 13\}
  \{1 7 18 19 14 15\}
  \{2 8 20 21 16 18\}
  \{5 11 17 19 22 23\}
  \{3 9 20 22 12 14\}
  \{4 10 21 23 13 15\}
  \{6 7 8 9 10 11\}
\}

set CubeCenters \{
  \{0 0 0 -1\}
  \{0 0 -1 0\}
  \{0 0 1 0\}
  \{0 -1 0 0\}
  \{0 1 0 0\}
  \{-1 0 0 0\}
  \{1 0 0 0\}
  \{0 0 0 1\}
\}

set Color(0) \{0 0 1\}
set Color(1) \{1 1 1\}
set Color(2) \{1 .5 0\}
set Color(3) \{0 1 1\}
set Color(4) \{1 0 1\}
set Color(5) \{0 1 0\}
set Color(6) \{1 0 0\}
set Color(7) \{1 1 0\}

Setup \{
  let (a,b,c) = \{(X pi/4,
     Y acos(2/sqrt(6)),
     Z acos(sqrt(3)/2))\}
  let M = ZW(c) YW(b) XW(a)
\}

Window controls -columns \{1 0\} -rows \{1 1 1\}
Frame hcube -in controls -at \{0 0 1 3\} \\
  -title \"Hypercube:\" -rows \{1 1 1 1 1\} \\
  -relief raised -bd 2 -bg grey75

Slider X 0 1 -title \"x-w rotation:\" \\
  -width 200 -in controls -at \{1 0\}
Slider Y 0 1 -title \"y-w rotation:\" \\
  -width 200 -in controls -at \{1 1\}
Slider Z 0 1 -title \"x-w rotation:\" \\
  -width 200 -in controls -at \{1 2\}

Axes \{x y z w\} -> \{x y z\}
}
  {selected 1 each}
  {{set w} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create 2_Hypercube/Edges {
  {Vertices $Vertices
Faces \{$Edges\}

Transform M

Frame cbox -in hcube -at \{0 4\}
CheckBox Show -title \"Show Edges\" -in cbox -at \{0 0\}
ShowMe Show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {{} {}}
}

####################

::class::Polyhedron Create 2_Hypercube/Faces {
  {proc CubeList \{C\} \{
  variables Color Cubes Faces
  set CC \{\}
  foreach c $C \{
    lappend CC [FaceList $c] \"<-\" \"color \{$Color($c)\}\"
  \}
  return $CC
\}

proc FaceList \{c\} \{
  variables Cubes Faces CubeCenters s
  set F \{\}
  set C [lindex $Cubes $c]
  set P [lindex $CubeCenters $c]
  foreach f $C \\
    \{lappend F [VertexList [lindex $Faces $f] $P $s]\}
  return $F
\}


proc VertexList \{f P \{t .01\}\} \{
  variable Vertices
  set V \{\}
  foreach i $f \{
    let Q = Vertices@i
    let Q = Q + t (P - Q)
    lappend V $Q
  \}
  return $V
\}

proc Outline \{faces \{t .1\}\} \{
  if \{$t == 1\} \{return $faces\}
  if \{$t == 0\} \{return \{\}\}
  set flist \{\}
  foreach face $faces \{
    if \{[lindex $face 1] == \"s\" || \\
        [llength [lindex $face 0]] != 4\} \{
      let (p_0,p_1,p_2,p_3) = face@0
      let P = (p_0 + p_1 + p_2 + p_3) / 4
      foreach i \{0 1 2 3\} \{let q_i = p_i + t (P - p_i)\}
      foreach i \{0 1 2 3\} \{
        let j = (i+1) % 4
        let f = (p_i,p_j,q_j,q_i)
        lappend flist [lreplace $face 0 0 $f]
      \}
    \} else \{
      lappend flist $face
    \}
  \}
  return $flist
\}

Vertices \{$Vertices\}
Faces \{[CubeList $C]\}

Transform \{lApply Outline t\} M

TypeIn C \"0 5 6 7\" -title \"Show Cubes:\" -in hcube -at \{0 1\} -titlewidth 12
TypeIn s .01 -title \"Shrink:\" -in hcube -at \{0 2\} -titlewidth 12
TypeIn t .15 -title \"Frame Width:\" -in hcube -at \{0 3\} -titlewidth 12
}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple}} 1}
  {flat 1.0 2 1 1 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}

####################

::class::Group Create 3_Complex_Function {
  {#
#  This example shows the graph of a complex
#  function as a surface in (real) 4-space.
#  That is, if z = x + iy and w = f(z) = u + iv
#  has graph (z,f(z)) in complex 2-space, or
#  (x,y,u,v) in real 4-space.  Mapping a region
#  of the xy-plane (complex plane) into four-space
#  yields a portion of the graph of f(z).
#  we use the unit disk in the xy-plane and
#  the function f(z) = z^n.
#
#  The graph is projected from four-space into
#  three space, but this example lets you specify
#  the direction for the projection.  The
#  \"View from\" panel allows you to specify
#  a viewpoint looking straight down one of the
#  four coordinate axes.  The view from the v-axis
#  shows the graph of the real part of f(z), while
#  the view from the u-axis shows the graph of the
#  imaginary part of f(z).  The view from the y-axis
#  shows the real part of the inverse relation for
#  f(z) which the view from the x-axis shows the
#  imaginary part of this relation.  Note that these
#  views have self-intersection since the inverse
#  relation is not a function (just as the inverse
#  of y = x^2 is multiple valued).
#
#  You can also look from (1,1,1,1), that is, along
#  the long diagonal of the bounding hypercube, or
#  you can specify your own viewpoint in four-space.
#
#  When you press one of the buttons or type in a
#  new viewpoint and press return, the graph
#  will rotate in four-space to move to the new 
#  viewpoint (you can change the number of steps
#  for the animation of this rotation below).
#  During the rotation, the current viewpoint is
#  displayed, (and where you are going from and to).
#  You can replay the animation in either direction
#  using the buttons at the bottom of the
#  \"Transtion\" panel, or you can drag the slider
#  bar to view any position along the way.
#
#  The bounding hypercube is shown along with the
#  graph as a means of helping you understand the
#  rotations that are occuring (just as a 3D
#  bounding box can make 2D pictures of solid
#  objects more readable).  One corner of the 
#  hypercube has colored segments that indicate the
#  different coordinate directions:  red for x, 
#  green for y, blue for u and white for v.
#  You can tell which view your are seeing by
#  noting which colors can (or can't be seen).
#  As you move from the view along the v-axis
#  to along the x-axis, for example, you should
#  see the red direction shrink and the white
#  one appear.  If you first understand the
#  rotations of the hypercube, you can use this
#  to help you understand the rotations of the
#  complex graph contained within it.
#
#  This example provides a means of navigating
#  all the various views of a complex function,
#  and should give insight into these important
#  mathematical objects that can't be obtained
#  by looking at the graphs of the real and
#  imagniary parts alone.
#

#
#  Remove \"-> \{x y u\}\" to get Geomview's native
#  4-dimensional mode
#
Axes \{x y u v\} -> \{x y u\}


#
#  The main windows
#
Window view -title \"View\" \\
  -rows \{1 1 \{0 5\} 0 1 1 1 1 \{0 5\} 1\} -columns \{1 1\}
Window transition -title \"Transition\" \\
  -rows \{1 1 1\} -columns 1
}
  {selected 1 keep}
  {{set v} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create 3_Complex_Function/Rotated {
  {#
#  This group object contains all the rotation
#  machinery, and is a bit complicated.
#

#
#  We start with all the control panel widgets
#
Frame label -title \"Viewed from:\" \\
  -in view -at \{0 3 2 1\}
Button X -title \"x-axis\" -in view -at \{0 4\} \\
  -command \{ViewFrom \{1 0 0 0\}\}
Button Y -title \"y-axis\" -in view -at \{1 4\} \\
  -command \{ViewFrom \{0 1 0 0\}\}
Button U -title \"u-axis\" -in view -at \{0 5\} \\
  -command \{ViewFrom \{0 0 1 0\}\}
Button V -title \"v-axis\" -in view -at \{1 5\} \\
  -command \{ViewFrom \{0 0 0 1\}\}
Button XYUV -title \"long diagonal\" \\
  -in view -at \{0 6 2 1\} \\
  -command \{ViewFrom \{.5 .5 .5 .5\}\}
Frame vbox -relief raised -bd 2 \\
  -in view -at \{0 7 2 1\} -rows 1 -columns 1
TypeIn V \"\" -evaluate -title \"Direction:\" \\
  -in vbox -at \{0 0\} \\
  -command \{if \{$V != \"\"\} \{ViewFrom [Unit $V]\}\}

Button reset -title \"Reset View\" \\
  -in view -at \{0 9 2 1\} -bg grey75\\
  -command \{Reset; Update\}

set dV0 \"\"; set dV1 \"\"; set dVP \"\"
Frame output -in transition -at \{0 0\} -bg grey75 \\
  -rows 1 -columns \{1 1\} -relief raised -bd 2
TypeOut dV0 -title \"From:\" -in output -at \{0 0\}
TypeOut dV1 -title \"To:\" -in output -at \{1 0\}
TypeOut dVP -title \"Current Viewpoint:\" \\
  -in output -at \{0 1 2 1\}
Slider pt 0 1 -title \"Percentage of transtion:\" \\
  -in transition -at \{0 1\} -width 200 -disabled
Evolve n nNext() nPrev() \\
  -title \"Animate transition:\" \\
  -in transition -at \{0 2\} -disabled \\
  -reset nReset()
Frame sbox -in transition -at \{0 3\} \\
  -relief raised -bd 2
TypeIn steps \"8\" -evaluate -in sbox -at \{0 0\} \\
  -title \"Steps for a rotation of pi/2:\" -width 4 \\
  -command \{ \}

#
#  This routine formats a vector for display
#  in one of the TypeOut widgets above.
#
proc Display \{V\} \{
  set VV \{\}
  foreach v $V \{
    set v [format \"%.3f\" $v]
    regsub \{(.)\\.?0+$\} $v \{\\1\} v
    lappend VV $v
  \}
  return \"([join $VV ,])\"
\}

#
#  This is bound to the \"Reset View\" button.
#  It sets the initial viewpoint and rotation
#  matrix, disbles the transtion animation widgets
#  and resets several other values.
#
proc Reset \{\} \{
  uplevel \{
    let VP = (0,0,0,1)

#
#  Identity matrix for 4D projective coordinates.
#  (the Transform directive uses projective
#   coordinates since these allow translations
#   to be represented by matrix multiplacation)
#
    let M = \{
      1 0 0 0 0
      0 1 0 0 0
      0 0 1 0 0
      0 0 0 1 0
      0 0 0 0 1
    \}

    set dV0 \"\"; set dV1 \"\"
    set dVP [Display $VP]
    set MM $M; set tn 1
    set V0 \"\"; set V1 \"\"

    catch \{
      Self Slider pt \{Enable; Set 0 0; Disable\}
      Self Evolver n Disable
    \}
  \}
\}

#
#  To change our view, we save the old matrix
#  and set the starting and ending viewpoints
#  (both for computation and for display).
#  We then determine the angle through which we
#  will be rotating, and determine the number
#  of steps we will take.
#  Then we reset the animator and start it running.
#
proc ViewFrom \{V\} \{
  variables V0 V1 VP MM M tn dV0 dV1 steps
  if \{[=== $V $VP]\} \\
    \{error \"Already viewing from that direction\"\}
  set MM $M
  let V0 = Unit(VP); let V1 = Unit(V)
  set dV0 [Display $V0]; set dV1 [Display $V1]
  let angle = acos(V0.V1)
  let tn = Max(1,ceil(2 steps * angle / pi))
  Self Evolver n Enable
  nReset
  Self Evolver n \{set inited 1; Run\}
\}

#
#  When the evolver is reset, we reset the slider
#  and stop the evolver.
#
proc nReset \{\} \{
  Self Slider pt \{Enable; Set 0 0\}
  Self Evolver n Stop
  return \"\"
\}

#
#  To go to the next step in the animation,
#  find out the closest current position and
#  add 1.  Find the new position of the slider
#  and set it to that value (but don't go past
#  the end).  If we are at the end, stop the
#  animation.
#
proc nNext \{\} \{
  variables pt tn
  let n = int(pt * tn + .5) + 1
  let nt = Min(n/tn, 1)
  Self Slider pt Set $nt 0
  if \{$nt == 1\} \{Self Evolver n Stop\}
  return \"\"
\}

#
#  To go to the previous step in the animation,
#  find out the closest current position and
#  subtract 1.  Find the new position of the
#  slider and set it to that value (but don't
#  go past the beginning).  If we are at the 
#  beginning, stop the animation.
#
proc nPrev \{\} \{
  variables pt tn
  let n = int(pt * tn + .5) - 1
  let nt = Max(n/tn, 0)
  Self Slider pt Set $nt 0
  if \{$nt == 0\} \{Self Evolver n Stop\}
  return \"\"
\}

#
#  If there is an animation in progress,
#  find the rotation that will take us to
#  to the current position in the animation.
#  Find the vector that is now along the v-axis
#  (the actual direction of projection for this
#  object).  Note that since M is a rotation
#  matrix, its inverse is its transpose; note also
#  the use of \"(:\" and \":)\" to pass the matrix
#  to the Transpose function as a single parameter
#  rather than each entry in the matrix as a
#  separate parameter.
#
Setup \{
  if \{$dV0 != \"\"\} \{
    let R = Rotate(V1,V0,pt acos(V0.V1))
    let M = MM R
    let VP = Transpose(:M:) (0,0,0,1)
    set dVP [Display $VP]
  \}
\}

#
#  make sure everything is set up
#
Reset

#
#  Transform the children of this group using
#  the rotation specified.
#
Transform \{Matrix M\}
}
  {always 1 keep}
  {{set v} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromSurface Create 3_Complex_Function/Rotated/Graph {
  {#
#  This object gets the precomputed data from
#  the Static group so that it won't have to be
#  computed each time the viewpoint changes.
#
#  The parent group's Transform directive
#  will cause this object to be rotated and
#  projected properly.
#

Frame fbox -in view -at \{0 1 2 1\} -relief raised -bd 2

CheckBox show 1 -title \"Show function graph\" \\
  -in fbox -at \{0 0\}
ShowMe show}
  {always 1 keep}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 2}
  {::sd::Patch 0 1 .25}
}

####################

::class::DataFromPolyhedron Create 3_Complex_Function/Rotated/Hypercube {
  {#
#  This object gets the precomputed data from
#  the Static group so that it won't have to be
#  computed each time the viewpoint changes.
#
#  The parent group's Transform directive
#  will cause this object to be rotated and
#  projected properly.
#}
  {always 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 3}
}

####################

::class::Group Create 3_Complex_Function/Static {
  {#
#  These objects are the prototyes that
#  live in four dimensional space, so we
#  cancel the projection used by the parent
#  group.
#
#  These objects are note displayed directly, 
#  but are used to prevent having to recompute
#  the graph every time the view changes.
#
Axes \{x y u v\}
}
  {hide 1 keep}
  {{set v} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Surface Create 3_Complex_Function/Static/Graph {
  {#
#  This is the graph of the function f(z)=z^n
#  over the unit disk, with a black boundary
#  edge to make it easier to see.
#


#
#  The degree of the polynomial
#
Slider n 0 6 2 -resolution 1 -title \"f(z) = z ^\" \\
  -width 100 -in view -at \{0 0 2 1\}

#
#  We compute the number of divisions needed
#  based on the degree of the polynomial
#
Setup \{let m = Max(24,16 n)\}

Domain \{
  \{\{0 1 10\} \{-pi pi m\}\}
  \{\{1 1 1\} \{-pi pi m\} LinesV \{0 0 0\}\}
\}

#
#  Do the function in polar coordinates.
#
Function \{r t\} \{
  let z = (x,y) = (r cos t, r sin t)
  let (u,v) = z^n
\}
}
  {always 1 keep}
  {{set v} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {2 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Polyhedron Create 3_Complex_Function/Static/Hypercube {
  {#
#  Here we give the coordinates of the hypercube
#  bounding box.  We want to color segments at
#  one corner, so there are extra vertices for that.
#

Vertices \{
 0000: (-1,-1,-1,-1)  0001: (-1,-1,-1,1)
 0010: (-1,-1,1,-1)   0011: (-1,-1,1,1)
 0100: (-1,1,-1,-1)   0101: (-1,1,-1,1)
 0110: (-1,1,1,-1)    0111: (-1,1,1,1)
 1000: (1,-1,-1,-1)   1001: (1,-1,-1,1)
 1010: (1,-1,1,-1)    1011: (1,-1,1,1)
 1100: (1,1,-1,-1)    1101: (1,1,-1,1)
 1110: (1,1,1,-1)     1111: (1,1,1,1)
 x000: (-.5,-1,-1,-1)
 0y00: (-1,-.5,-1,-1)
 00u0: (-1,-1,-.5,-1)
 000v: (-1,-1,-1,-.5)
\}

#
#  The edges come in four groups, each group
#  parallel to one of the four coordinate axes.
#
#  The extra edges at the end are the colored
#  segments, which are extra wide to make them
#  more visible.
#
Faces \{
 \{000v 0001\} \{0010 0011\} \{0100 0101\} \{0110 0111\}
 \{1000 1001\} \{1010 1011\} \{1100 1101\} \{1110 1111\}

 \{00u0 0010\} \{0001 0011\} \{0100 0110\} \{0101 0111\}
 \{1000 1010\} \{1001 1011\} \{1100 1110\} \{1101 1111\}

 \{0y00 0100\} \{0001 0101\} \{0010 0110\} \{0011 0111\}
 \{1000 1100\} \{1001 1101\} \{1010 1110\} \{1011 1111\}

 \{x000 1000\} \{0001 1001\} \{0010 1010\} \{0011 1011\}
 \{0100 1100\} \{0101 1101\} \{0110 1110\} \{0111 1111\}

 \{
   \{0000 x000\} <- \{color \{1 0 0\}\}
   \{0000 0y00\} <- \{color \{0 1 0\}\}
   \{0000 00u0\} <- \{color \{0 0 1\}\}
   \{0000 000v\} <- \{color \{1 1 1\}\}
 \} <- \{width 5\}
\}}
  {always 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {3 {}}
}

####################

::class::Group Create 4_Slice-Cube {
  {#
#  This example shows a cube passing through a
#  plane and the slice of the cube within
#  that plane.  It's not really a 4D example, 
#  but it is one of the analogies used for
#  understanding slices of 4D object (like in the
#  next example).
#
#  This also shows how you can use menus to
#  select the viewpoint, and how the Transform
#  directive can be used to do some pretty
#  fancy computation, in this case, to modify
#  the results of a Levels computation.
#
#  The Levels object doesn't really know how to
#  slice solids (only surfaces), so this example
#  shows how to simulate slicing for convex solids
#  (one could combine several convex solids to slice
#  a more complex solid).  The code given here
#  could server as the basis for a higher-
#  dimensional slicing object, and should probably
#  be made into one eventually.
#

#
#  The control panels
#
Window controls -rows \{1 1\} -columns 1
Frame top -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows 1 -columns \{0 \{1 10\} 0\}

#
#  The number of steps to use for the slicing.
#  The total steps will be (steps + 2 stepsAbove)
#  with the number of steps before the cube hits
#  the plane being \"stepsAbove\", the number where
#  the plane actually cuts the cube being \"steps\"
#  and the number after the cube passes through
#  the plane is \"stepsAbove\" again.
#
#  If you change these, you need to select the
#  Cube object and update it (so that the animator
#  will be redefined in terms of these values).
#
set steps 18
set stepsAbove 2

#
#  Button to set starting viewpoint
#
Button reset -title \"Set Initial Viewpoint\" \\
  -in controls -at \{0 2\} -bg grey75

#
#  If the reset button is pressed,
#  Tell Geomview the commands needed to set
#  the initial viewpoint, and set the 
#  animator to the initial position (the second
#  0 in the Set command prevents the animator
#  from doing an update, since we are about to
#  do one already).
#
Setup \{
  if \{$reset\} \{
    let x = -pi/2.6
    TellGV \\
     \"(progn\" \\
     \" (new-center World)(camera-reset focus)\" \\
     \" (transform World World focus rotate $x 0 0)\" \\
     \" (transform World World focus translate 0 .25 0)\" \\
     \")\"
    Child Cube Animator n \\
     \{Set 0 0; set direction \"forward\"\}
  \}
\}}
  {selected 1 keep}
  {{ list 0 0 0} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create 4_Slice-Cube/Cube {
  {#
#  These matrices represent the rotations for
#  the different viewpoints.  They are indexed
#  by the dimension of the first facet of the
#  cube to hit the plane.
#
let M_2 = Scale(1); # the identity matrix
let M_1 = XZ(pi/4)
let M_0 = XY(pi/2.8-pi) \\
          Rotate((1,1,1),(0,0,1),atan(sqrt(2))) 

#
#  Make sure these variables exist
#
let h = 0; let t = 0

#
#  We locate the current height based
#  on the value of the animator and the
#  orientation of the cube.
#
#  The dh variable is the step size (for height)
#

Setup \{
  let dh = 2 sqrt(3-d) / steps
  let h = (1 - 2t) (sqrt(3-d) + dh stepsAbove)
\}

#
#  The animator widget
#
Animate n \{steps + 2 stepsAbove\} \{t 0 1\} \\
  -title \"Position\" -in controls -at \{0 1\}

#
#  The dimension of the facet that first hits
#  the plane.
#
PopUp d \{\{Face First\} \{Edge First\} \{Corner First\}\} \\
  -values \{2 1 0\} -title \"Slice:\" \\
  -in top -at \{0 0\}

#
#  We rotate the cube to the properorientation
#  and then translate it by the given height
#  (so that the cube goes through the plane
#  rather than the plane through the cube).
#
Transform \{Translate(0,0,h)\} \{Matrix M_d\}
}
  {always 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create 4_Slice-Cube/Cube/Edges {
  {#
#  We get the edges from a prototype so that
#  the unrotated coordinates only have to be
#  computed once.
#

#
#  We only show the edges of the cube so we can
#  See the slice within it.
#}
  {always 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 4}
}

####################

::class::DataFromPolyhedron Create 4_Slice-Cube/Cube/Faces {
  {#
#  We get the faces from a prototype so that
#  the unrotated coordinates only have to be
#  computed once.
#

#
#  We don't show the faces; they are only here
#  so that they will be transformed by the
#  group's Transformation directive.  They
#  are then sliced by the Slice-Edges object.
#}
  {hide 1 keep}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {0 5}
}

####################

::class::Polyhedron Create 4_Slice-Cube/Plane {
  {#
#  This is the slicing plane.
#

Faces \{
 \{(-2,-2,-0.01) ( 2,-2,-0.01) 
  ( 2, 2,-0.01) (-2, 2,-0.01)\}
\}}
  {always 1 keep}
  {{ list 1 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create 4_Slice-Cube/Proto {
  {#
#  We use prototype objects that are not shown
#  so that the basic coordinates of the cube
#  only have to be computed once, not every
#  time the height or rotation changes.
#

#
#  This vertex list is used by both child objects.
#

set Vertices \{
 000: (-1,-1,-1)  001: (-1,-1,1)
 010: (-1,1,-1)   011: (-1,1,1)
 100: (1,-1,-1)   101: (1,-1,1)
 110: (1,1,-1)    111: (1,1,1)
\}
}
  {hide 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create 4_Slice-Cube/Proto/Edges {
  {#
#  The edges of the cube.
#

Vertices $Vertices

Faces \{
 \{000 001\} \{010 011\} \{100 101\} \{110 111\}
 \{000 010\} \{001 011\} \{100 110\} \{101 111\}
 \{000 100\} \{001 101\} \{010 110\} \{011 111\}
\}

}
  {hide 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {4 {}}
}

####################

::class::Polyhedron Create 4_Slice-Cube/Proto/Faces {
  {#
#  The faces of the cube.
#

Vertices $Vertices

Faces \{
 \{000 001 011 010\} \{100 101 111 110\}
 \{000 001 101 100\} \{010 011 111 110\}
 \{000 010 110 100\} \{001 011 111 101\}
\}

}
  {hide 1 keep}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {5 {}}
}

####################

::class::Levels Create 4_Slice-Cube/Slice-Edges {
  {#
#  Here we compute the intersection of the
#  rotated and translated cube with the slicing
#  plane.  The plane is always at height z=0
#  and the cube moves through it.
#

Height z = 0
}
  {always 1 keep}
  {{ list 0 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {1 0}
}

####################

::class::DataFromPolyhedron Create 4_Slice-Cube/Slice-Faces {
  {#
#  This object is linked to the Slice-Edges
#  object and used a lApply transformation
#  to modify complete list of faces.  The idea
#  is to take the edges computed by Slice-Edges
#  and fill them in to get faces in the middle.
#
#  The simplest way to do this is to find a point
#  in the center of the slice and connect each
#  edge to this new point, thus forming a triangle.
#  This way, we don't have to worry about the
#  order of the edges around the slice polygon that
#  we are trying to form.
#

Transform \{lApply Slice\}

#
#  First we separate the slice faces by dimension
#  (vertices, edges, faces).  If there are any
#  complete faces in the slice (like when the
#  bottom of the cube just touches the plane),
#  then return the emtpy list (Slide-Edges will
#  show these faces).
#
#  Otherwise, if there are no edges, return
#  the vertex list (the only faces remaining).
#  If there are only one or two edges, return
#  them (they don't form a polygon).
#  Otherwise, we need to make new faces.
#  Start by finding a vertex in the center.
#  (In our case, we know the origin is at the
#  center, by symmetry.  If you use a different
#  polyhedron, you should uncomment the lines
#  that average the vertices of the slice edges;
#  provided the slice is convex, this will be
#  a point in the interior.)  Note that the
#  faces are really lists that contain more
#  than just the vertices (the first element in
#  the list is the vertex list; the remainder
#  is other data, like color, line width, etc.),
#  so we use e@0 to get the vertices.
#
#  Once we have the central point, we go through
#  the edge list again and insert the point at
#  the end of the vertex list for each face.  This
#  make each edge into a triangle, and the resulting
#  triangles fit together to form the complete
#  slice polygon.
#

proc Slice \{faces\} \{
  let (V,E,F) = Separate(:faces:)
  if \{[llength $F] > 0\} \{return \{\}\}
  switch [llength $E] \{
    0 \{return $V\}
    1 - 2 \{return $E\}
    default \{
      set P \{0 0 0\}
#      foreach e $E \{
#        let (p0,p1) = e@0
#        let P = P + p0 + p1
#      \}
#      let P = P / (2 llength(:E:))
      set flist \{\}
      foreach e $E \{
        set e [lreplace $e 0 0 \\
                 [concat [lindex $e 0] [list $P]]]
        lappend flist $e
      \}
      return $flist
    \}
  \}
\}

#
#  We separate the faces by counting the
#  number of vertices in each face.  Remember
#  that the vertex list is the first element
#  in each face in the face list.
#
proc Separate \{faces\} \{
  foreach i \{1 2 3\} \{set F($i) \{\}\}
  foreach f $faces \\
    \{lappend F([llength [lindex $f 0]]) $f\}
  return [list $F(1) $F(2) $F(3)]
\}

#
#  Use a checkbox to determine whether we want
#  to view the solid slice or not.
#
CheckBox Show -title \"Filled\" -in top -at \{2 0\}
ShowMe Show
}
  {always 1 keep}
  {{ list 0 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
}

####################

::class::Group Create 5_Slice-HCube {
  {#
#  This demonstration provides a platform for
#  exploring the slices of a hypercube.  It lets
#  you set the type of projection to use
#  (orthographic or sterographic) and the projection
#  direction.  You can specify which cubes to show
#  with solid faces, and how much of each face to
#  show.
#
#  The slicing controls allow you to slice any of
#  the cubical faces of the hypercube to slice, 
#  whether to fill in the slice faces, and by how
#  much.  You can specify the height at which to
#  slice, and can move through various predefined
#  heights that show the important slices of the
#  hypercube for the given projection direction.
#  You can specify the direction as a vector, or
#  by selecting the type and index of the facet
#  you want the slice to hit first.  Finally,
#  you can animate the slicing sequence.
#
#  The demo makes sophisticated use of the various
#  widget types, and their more advanced options.
#


#
#  The control windows
#

Window hcube -title \"Projection Controls\" \\
  -rows \{1 1 1\} -columns \{0 1\}
Window slice -title \"Slice Controls\" \\
  -rows \{1 1 1\} -columns 1

#
#  This button asks Geomview to renormalize
#  the object, thus making it fit to the window.
# 
Button renormalize -title \"Fit to window\" \\
  -in hcube -at \{1 2\} -command FitToWindow \\

proc FitToWindow \{\} \{
  TellGV \\
    \"(progn\" \\
    \" (normalization [Self Name] each)\" \\
    \" (normalization [Self Name] keep)\" \\
    \")\" 
\}

#
#  This button asks Geomview to rescale the
#  object, making it larger.
#
Button enlarge -title \"Enlarge\" -command Enlarge \\
  -in hcube -at \{1 3\}

proc Enlarge \{\} \{
  TellGV \"(scale [Self Name] 1.2)\"
\}

#
#  Prepare a vector for output
#
proc DisplayV \{V\} \{
  set VV \{\}
  foreach v $V \{
    set v [format \"%.3f\" $v]
    regsub \{(.)\\.?0+$\} $v \{\\1\} v
    lappend VV $v
  \}
  return \"([join $VV ,])\"
\}}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create 5_Slice-HCube/Projected {
  {#
#  This object takes the data computed in the
#  Proto object and projects it into three-space.
#  The Proto object does not have to be recomputed
#  every time the projection changes, so this
#  improves performance for changes in projection.
#

#
#  First we set up the Slice Controls window
#  (it's pretty complicated)
#
Frame vbox -in hcube -at \{0 0 2 1\} -relief raised -bd 2 \\
  -rows \{1 1\} -columns \{1 0 1\}

#
#  The projection direction
#
TypeIn VP \"(0,0,0,1)\" -evaluate \\
  -title \"Project from:\" -in vbox -at \{0 0 3 1\} \\

#
#  A menu that lets us choose a predefined
#  direction for the viewpoint.
#
PopUp setVP \{Cube Face Edge Corner \{Linked Cubes\} 
             \{Touching Cubes\} \{Offset Cubes\}\} \\
  -title \"Set projection to look at:\" \\
  -values \{3 2 1 0 -1 -2 -3\} -in vbox -at \{1 1\} \\
  -command \{SetVP\}

#
#  One over the distance to the projection point.
#  (This makes  0 be orthographic, and provides
#  a continuous transition from stereo to
#  orthographic projection).
#
Slider d 0 1 -width 300 -in hcube -at \{0 1 2 1\} \\
  -title \"Projection distance (0 = orthographic):\"

#
#  These are the viewpoints for the menu above
#  The last three use non-orthogonal projections
#  and the Pd values determine the offset.
#
let P_3 = (0,0,0,1)
let P_2 = (0,0,1,1)
let P_1 = (0,1,1,1)
let P_0 = (1,1,1,1)
let P_(-1) = (0,0,0,1); let Pd_(-1) = 2/3
let P_(-2) = (0,0,0,1); let Pd_(-2) = 1
let P_(-3) = (0,0,0,1); let Pd_(-3) = 4/3

#
#  This is the skew projection matrix.
#
vproc MP \{d\} \{
  variable Pd
  set d $Pd($d)
  let M = Scale(.5) \{
    1 0 0 -d 0
    0 1 0 -d 0
    0 0 1 -d 0
    0 0 0  0 0
    0 0 0  0 1
  \}
  return $M
\}

#
#  When a menu item is selected, change the
#  viewpoint appropriately.  (This will
#  cause an update to occur.)
#
proc SetVP \{\} \{
  variables setVP P
  Self TypeIn VP Set [DisplayV $P($setVP)]
\}

#
#  When this object is computed, get the
#  stereo projection distance (0 = orthographic)
#  and get the unit projection direction.
#  If we are doing a skew projection
#    get the matrix for it
#   Otherwise
#    use the matrix that rotates the viewpoint
#      to the positive w-axis
#  
Setup \{
  if \{$d == 0\} \{set dd 0\} else \{let dd = 2/d\}
  let V = Unit(VP)
  if \{$setVP < 0\} \{
   let M = MP(setVP)
  \} else \{
   let M = Rotate(V,(0,0,0,1),acos(V@3))
  \}
\}

#
#  Transform the group by the given matrix
#  and project it stereographically (if dd != 0)
#
Transform \{Matrix M\} 
Axes \{x y z w\} -> \{x y z\} -stereo dd
}
  {always 1 keep}
  {{set w} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromPolyhedron Create 5_Slice-HCube/Projected/Edges {
  {#
#  This simply links to the Proto/Edges object
#  and duplicates that data.  The edges will only
#  be computed the first time through, and from
#  then on the data will be cached in the Proto
#  object.
#
}
  {always 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 6}
}

####################

::class::DataFromPolyhedron Create 5_Slice-HCube/Projected/Faces {
  {#
#  Like the edges object, this links to the
#  prototypes for efficiency.
#}
  {always 1 keep}
  {{set w} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 7}
}

####################

::class::DataFromPolyhedron Create 5_Slice-HCube/Projected/Slices {
  {#
#  This also gets its data from the Proto object.
#  We use the checkbox in the Proto/Slices
#  object to determine whether to show this one
#  or not (this object inherits the value from
#  Proto/Slices since this object links to
#  the Proto/Slices object).
#

ShowMe Show}
  {always 1 keep}
  {{set w} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 8}
}

####################

::class::Group Create 5_Slice-HCube/Proto {
  {#
#  This group contains objects that do all
#  the computation, though the group does not
#  itself get displayed (its OBJECT/SHOW menu
#  is set to NEVER).  The Projected object
#  links to these objects, and performs the
#  projection and display.  The Proto objects
#  serve as caches for the data so that the
#  objects don't have to be recomputed if the
#  projection changes.
#

#
#  These objects reside in four dimensions
#  (the projections are done in the Projected
#  object).
#

Axes \{x y z w\}

#
#  The vertices of a hypercube:
#
set Vertices \{
  \{-1 -1 -1 -1\} \{1 -1 -1 -1\} \{-1 1 -1 -1\} \{1 1 -1 -1\}
  \{-1 -1 1 -1\} \{1 -1 1 -1\} \{-1 1 1 -1\} \{1 1 1 -1\}
  \{-1 -1 -1 1\} \{1 -1 -1 1\} \{-1 1 -1 1\} \{1 1 -1 1\}
  \{-1 -1 1 1\} \{1 -1 1 1\} \{-1 1 1 1\} \{1 1 1 1\}
\}

#
#  The vertices in each cubical face:
#
set CubeV \{
  \{0 1 2 3 4 5 6 7\}
  \{8 9 10 11 12 13 14 15\}
  \{0 2 4 6 8 10 12 14\}
  \{1 3 5 7 9 11 13 15\}
  \{0 1 4 5 8 9 12 13\}
  \{2 3 6 7 10 11 14 15\}
  \{0 1 2 3 8 9 10 11\}
  \{4 5 6 7 12 13 14 15\}
\}

#
#  Within a cube, the indices of faces:
#
set cFaces \{
  \{0 4 6 2\} \{1 3 7 5\}
  \{0 1 5 4\} \{2 6 7 3\}
  \{0 2 3 1\} \{4 5 7 6\}
\}
#
#  Within a face, the indices of the edges:
#
set fEdges \{\{0 1\} \{1 2\} \{2 3\} \{3 0\}\}

#
#  The colors for the cubes:
#
set Color \{
  \{1 0 0\}
  \{0 0 1\}
  \{0 1 0\}
  \{1 1 0\}
  \{1 0 1\}
  \{0 1 1\}
  \{1 .5 0\}
  \{1 0 .5\}
\}

set LightColor \{
  \{1 .3 .3\}
  \{.3 .3 1\}
  \{.3 1 .3\}
  \{1 1 .3\}
  \{1 .3 1\}
  \{.3 1 1\}
  \{1 .7 .3\}
  \{1 .3 .7\}
\}

#
#  Various lists of parts:
#
set EdgeV \{\}
set FaceE \{\}
set CubeF \{\}
set FaceV \{\}

########################
#
#  Procedures to create the part lists
#

#
#  Given the vertices of a face,
#  Get the id of this face
#  Add the face to FaceV (list of vertices by face)
#  For each edge in a generic face
#    Get the sorted vertices of the edge
#    If this edge is new
#      Get a new id for it and add the edge
#        to EdgeV (list of vertices by edge)
#    Add the edge ID to the face
#  Add the face's edges to FaceE (list of
#    edges by face)
#  Return the face ID
#
proc FaceEdges \{face\} \{
  variables FaceE FaceV EdgeV fEdges
  upvar eID eID
  set id [llength $FaceV]
  lappend FaceV $face
  set f \{\}
  foreach edge $fEdges \{
    set e [lsort -integer [list \\
      [lindex $face [lindex $edge 0]] \\
      [lindex $face [lindex $edge 1]] \\
    ]]
    if \{![info exists eID($e)]\} \{
      set eID($e) [llength $EdgeV]
      lappend EdgeV $e
    \}
    lappend f $eID($e)
  \}
  lappend FaceE $f
  return $id
\}

#
#  For each cube in the list
#    For each face in a generic cube
#      Get the list of vertices in the face
#      Sort it
#      If this is a new face
#        Get the edges in this face and save
#          the new face's ID
#      Add the face ID to the cube's list
#    Add the face ID list to CubeF (list of
#      faces bu cube).
#
proc CubeFaces \{cubes\} \{
  variables CubeF cFaces
  foreach cube $cubes \{
    set c \{\}
    foreach face $cFaces \{
      set f \{\}
      foreach v $face \{lappend f [lindex $cube $v]\}
      set fs [lsort -integer $f]
      if \{![info exists fID($fs)]\} \\
        \{set fID($fs) [FaceEdges $f]\}
      lappend c $fID($fs)
    \}
    lappend CubeF $c
  \}
\}

#
#  Make the data for the hypercube
#
CubeFaces $CubeV

#########################################
#
#  Here we compute the slicing directions
#  for use in the slicing panel.  To slice
#  so that you hit a given facet first,
#  slice in the direction from the center
#  of the facet to the origin.
#

#
#  Find the centers of the facets
#
proc Centers \{faces\} \{
  variable Vertices
  set vlist \{\}
  foreach face $faces \{
    set P \{0 0 0 0\}
    foreach v $face \{let P = P + Vertices@v\}
    let P = -P / llength(:face:)
    lappend vlist $P
  \}
  return $vlist
\}

#
#  The directions for slicing the hypercube
#  parallel to each n-facet.
#
foreach type \{Cube Face Edge\} i \{3 2 1\} \\
  \{set U($i) [Centers [set $\{type\}V]]\}
set U(0) $Vertices

#
#  The heights for slicing the hypercube
#  parallel to an n-facet
#
let H_3 = \{0 1/3 2/3 1\}
let H_2 = \{0 1/4 1/2 3/4 1\}
let H_1 = \{0 1/6 1/3 1/2 2/3 5/6 1\}
let H_0 = \{0 1/8 1/4 3/8 1/2 5/8 3/4 7/8 1\}
}
  {hide 1 keep}
  {{set w} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create 5_Slice-HCube/Proto/Edges {
  {#
#  This is the data for the edges of the
#  hypercube.  It never changes once it is
#  computed.
#

Vertices $Vertices
Faces \{$EdgeV\}

Precomputed -vertices -faces
}
  {always 1 keep}
  {{set w} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {6 {}}
}

####################

::class::Polyhedron Create 5_Slice-HCube/Proto/Faces {
  {#
#  This is the data for the faces of the
#  hypercubes that the user has requested
#  to be shown as solid cubes.
#

Frame fbox -in hcube -at \{0 2 1 2\} \\
  -rows \{1 1\} -columns \{0 1\} -relief raised -bd 2

#
#  The indices of the cubes to show
#
TypeIn Cubes \{\} -evaluate -in fbox -at \{0 0\} \\
  -title \"Show these cubes:\"
 
#
#  How much to show of each face.
#
TypeIn s \{1/10\} -evaluate -in fbox -at \{0 1\} -width 5 \\
  -title \"Fraction of face to show:\"

#
#  We use the vertices from the hypercube
#  and compute the faces below.
#
Vertices $Vertices
Faces \{$Faces\}

Precomputed -vertices -vlist -faces

#
#  For each each cube showing
#    For each face in that cube
#      Add the face to the face list
#    Add the color specification for the cube
#
Setup \{
  set Faces \{\}
  foreach c $Cubes \{
    set flist \{\}
    foreach f [lindex $CubeF $c] \\
      \{lappend flist [lindex $FaceV $f]\}
    lappend Faces $flist \"<-\" \\
      [list color [lindex $Color $c]]
  \}
\}


#
#  This procedure takes a list of quadrilaterals
#  and returns a list of faces that form the
#  outer edges of the quadrilaterals.  The width
#  of the edges is given by \"t\".  See the
#  polygon examples for more details about
#  how this works.
#
proc Outline \{faces \{t .2\}\} \{
  if \{$t == 1\} \{return $faces\}
  if \{$t == 0\} \{return \{\}\}
  set flist \{\}
  foreach face $faces \{
    let (p_0,p_1,p_2,p_3) = face@0
    let P = (p_0 + p_1 + p_2 + p_3) / 4
    foreach i \{0 1 2 3\} \{let q_i = p_i + t (P - p_i)\}
    foreach i \{0 1 2 3\} j \{1 2 3 0\} \{
      let f = (p_i,p_j,q_j,q_i)
      lappend flist [lreplace $face 0 0 $f]
    \}
  \}
  return $flist
\}

#
#  Here we apply the Outline function to the
#  complete face list.  Since the routine
#  changes the number of faces, we need to use
#  lApply.
#
Transform \{lApply Outline s\}
}
  {always 1 keep}
  {{set w} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {7 {}}
}

####################

::class::Polyhedron Create 5_Slice-HCube/Proto/Slices {
  {#
#  This is the heart of the demonstration.  It
#  computes the slices of the hypercube.
#

#
#  First set up the Slice Controls window.
#

Frame top -in slice -at \{0 0\} -relief raised -bd 2 \\
  -rows \{1 1 1\} -columns \{\{0 20\} 0 \{0 10\} 0 \{0 20\}\}
Frame height -in slice -at \{0 1\} -relief raised -bd 2\\
  -rows \{1 1 \{0 2\} 1\} -columns 1
Frame h1 -in height -at \{0 0\} -rows 1 -columns 1
Frame h2 -in height -at \{0 4\} -rows 1

#
#  The cubes whose slices will be shown.
#
TypeIn Cubes \"0 1 2 3 4 5 6 7\" -evaluate \\
  -in top -at \{0 0 5 1\} -title \"Slice these cubes:\"

#
#  Portion of slice faces to show.
#
TypeIn s \"1\" -evaluate -width 5 \\
  -in top -at \{0 1 5 1\} -title \"Fraction of faces to show:\"

CheckBox Show 0 -title \"Show slice\" -in top -at \{1 2\}
CheckBox filled 1 -title \"Filled\" -in top -at \{3 2\}

#
#  The (normalized) height of the slice.
#
TypeIn h \"0.00\" -evaluate -in h1 -at \{0 0\} \\
  -title \"Slice at height:\" -width 5

#
#  Buttons for moving among the predefined heights
#  for a given slice direction.
#
Button firstH -title \"|<\" -in h1 -at \{1 0\} \\
  -command \{Self TypeIn h Set [lindex $H($setD) 0]\}
Button prevH -title \"<\" -command PrevH \\
  -in h1 -at \{2 0\}
Button nextH -title \">\" -command NextH \\
  -in h1 -at \{3 0\}
Button lastH -title \">|\" -in h1 -at \{4 0\} \\
  -command \{Self TypeIn h Set [lindex $H($setD) end]\}

#
#  The slice direction.
#
TypeIn D \"(0,0,0,1)\" -evaluate -in height -at \{0 1\} \\
  -title \"In the direction of:\"

#
#  Select the type of facet to hit first by
#  the slicer.
#
PopUp setD \{Cube Face Edge Corner\} \\
  -values \{3 2 1 0\} -title \"Slice first at\" \\
  -command \{Self TypeIn faceD Set 0 0\} \\
  -in h2 -at \{0 0\}

#
#  And which one of that type to hit first.
#
TypeIn faceD \"1\" -evaluate -in h2 -at \{1 0\} \\
  -title \"number\" -width 4 -command \{SetD $faceD\}
Button prevD -title \"<\" -in h2 -at \{2 0\} \\
  -command \{Self TypeIn faceD Set [incr faceD -1]\} \\
  -disabled
Button nextD -title \">\" -in h2 -at \{3 0\} \\
  -command \{Self TypeIn faceD Set [incr faceD]\} \\

#
#  Animate the slicing sequence.
#
Animate count 24 \{TypeIn h 0 1\} \\
  -title \"Animate Slice: height\" -in slice -at \{0 2\}


#
#  This routine sets a new slice direction
#
#  If the facet index is out of range, report that.
#  Enable the next and previous buttons
#  If it is the first facet, disable previous
#  If it is the last facet, disable next
#  Set the slice direction and height.
#  Reset the animation (without updating)
#  Update (note: this guarantees an update;
#    setting the animator would not cause an
#    update if the value were already 0.)
#
proc SetD \{n\} \{
  variables U setD
  set m [llength $U($setD)]
  if \{$n < 0 || $n >= $m\} \{
    set type [lindex \{Corner Edge Face Cube\} $setD]
    Error \"$type number must be between 0 and $m\"
  \}
  set faceD $n
  Self Button \{prevD Enable; nextD Enable\}
  if \{$n == 0\} \{Self Button prevD Disable\}
  if \{$n == $m-1\} \{Self Button nextD Disable\}
  Self TypeIn h Set 0 0
  Self TypeIn D Set [DisplayV [lindex $U($setD) $n]] 0
  Self Animator count Reset 0
  Update
\}

#
#  To get the next height, locate the next
#  largest height in the list of predefined
#  heights and set the TypeIn to that value.
#
proc NextH \{\} \{
  variables H h setD
  foreach height $H($setD) \{
    if \{$height > $h || $height == 1\} \{
      if \{$height != $h\} \{Self TypeIn h Set $height\}
      break
    \}
  \}
\}

#
#  To go back a height, look through the list of
#  predefined heights until we find one that is
#  as large as the current height, and then use
#  the height before that one.
#  
proc PrevH \{\} \{
  variables H h setD
  set hh 0
  foreach height $H($setD) \{
    if \{$height >= $h\} break
    set hh $height
  \}
  if \{$hh != $h\} \{Self TypeIn h Set $hh\}
\}


###############################################
#
#  The main computation routines
#

set HeightV \{\};    # the vertex heights
set IntersectE \{\}; # the sliced of edges
set IntersectF \{\}; # the sliced faces

#
#  Here we compute the height at all the vertices
#  and normalize them.  The results are stored
#  in a variable HeightV
#
proc HeightV \{V t\} \{
  variables HeightV Vertices
  set HeightV \{\}; set H \{\}
  set min 100000; set max -100000
  foreach v $Vertices \{
    let h = v.V; lappend H $h
    if \{$h > $max\} \{set max $h\}
    if \{$h < $min\} \{set min $h\}
  \}
  if \{$min < $max\} \{
    foreach h $H \{
      let h = (h-min)/(max-min) - t
      lappend HeightV $h
    \}
  \}
\}

#
#  Here we compute the slice points for all the
#  edges.
#
#  For each edge in the edge list
#    Get the vertices of the edge and their heights.
#    If the heights have opposite signs
#      compute the intersection point and save it
#    Otherwise record no intersection
#
proc IntersectE \{\} \{
  variables IntersectE HeightV Vertices EdgeV
  set IntersectE \{\}
  foreach e $EdgeV \{
    set v0 [lindex $Vertices [lindex $e 0]]
    set v1 [lindex $Vertices [lindex $e 1]]
    set h0 [lindex $HeightV [lindex $e 0]]
    set h1 [lindex $HeightV [lindex $e 1]]
    if \{$h0*$h1 < 0\} \{
      let v = (h0 v1 - h1 v0) / (h0 - h1)
      lappend IntersectE $v
    \} else \{
      lappend IntersectE \{\}
    \}
  \}
\}

#
#  Find the slices of the faces.
#
#  Foreach face in the face list (fe gives the
#      indices of the edges around the face, and
#      fv the indices of the vertices of the face).
#    Foreach edge in the face
#      If the edge has an intersection, save it
#    Foreach vertex in the face
#      If the vertex is at the right height, save it.
#    Save the slice data for the face.
#
proc IntersectF \{\} \{
  variables IntersectF IntersectE HeightV
  variables FaceE FaceV Vertices
  set IntersectF \{\}
  foreach fe $FaceE fv $FaceV \{
    set E \{\}
    foreach e $fe \{
      if \{[llength [lindex $IntersectE $e]] > 0\} \\
        \{lappend E [lindex $IntersectE $e]\}
    \}
    foreach v $fv \{
      if \{[lindex $HeightV $v] == 0\} \\
        \{lappend E [lindex $Vertices $v]\}
    \}
    lappend IntersectF $E
  \}
\}

#
#  Find the face data for the slices of the cubes
#
#  For each cube in the list
#    For each face of the cube
#      Get the intersections with that face
#      Add edges to the edge list and faces
#        to the face list.
#    If there are edges in the intersection
#      Add them to the complete edge list.
#      If there are no faces, fill in the edges
#    If there are faces in the intersection
#      Add them to the complete face list with
#        the correct color for this cube.
#  If there are edges in the intersection
#    Make one list of them
#    Add the color specification
#  Return the list of faces and edges
#
proc IntersectC \{cubes\} \{
  variables IntersectF CubeF LightColor
  set CF \{\}; set CE \{\}
  foreach c $cubes \{
    set F \{\}; set E \{\}
    foreach f [lindex $CubeF $c] \{
      set e [lindex $IntersectF $f]
      switch [llength $e] \{
        2 \{lappend E $e\}
        4 \{lappend F $e\}
      \}
    \}
    if \{[llength $E] > 0\} \{
      lappend CE $E
      if \{[llength $F] == 0\} \{set F [FilledFace $E]\}
    \}
    if \{[llength $F] > 0\} \{
      lappend CF $F \"<-\" \\
        [list color [lindex $LightColor $c]]
    \}
  \}
  if \{[llength $CE] > 0\} \{
    set CE [list [join $CE]]
    lappend CE <- \{color \{1 1 1\} width 4\}
  \}
  return [concat $CF $CE]
\}

#
#  This routine fills in the face given its
#  bounding edges.
#
#  If we aren't filling in faces, return nothing.
#  Find the center of the face by averaging the
#  vertices that form the edges.
#  Foreach edge in the list
#    Add the center to the end of the edge, thus
#      making it a triangle.
#  Return the list of triangle so formed
#
proc FilledFace \{edges\} \{
  variable filled
  if \{!$filled\} \{return \{\}\}
  set P \{0 0 0 0\}
  foreach e $edges \{
    let (v0,v1) = e
    let P = P + v0 + v1
  \}
  let P = P / (2 llength(:edges:))
  set faces \{\}
  foreach e $edges \\
    \{lappend faces [linsert $e end $P]\}
  return $faces
\}


#
#  This routine displays only a portion of the
#  faces in the slice.  it is a modified version
#  of similar routines used in other examples, but
#  this one takes advantage of knowing which
#  faces already have the centers computed (the
#  triangles, where the center is the third vertex).
#  
#  For each face in the list,
#    Get the vertex list (the rest of the face is
#      other data used by the Polyhedron object).
#    Find out the number of vertices in the face
#    If it is a point or line, use it as it is.
#    If it is a triangle and part should be showing,
#      Get the vertices of the face (p_2 is the
#        center already computed when the face
#        was generated by FilledFace above.
#      Get the points along the edges from this
#        vertex toward the other two vertices that
#        gives the proper percentage of the face
#      Get the new vertex list for the face
#      Add the modified face back into the list
#    If it is a quadrilateral, it must be divided
#      Get the vertices of the face.
#      Find the center.
#      Find the new points partway toward the center.
#      Foreach edge in the face
#        Get the vertex list for the piece of
#          the face along that edge.
#        Add the modified face to the list.
#  Return the modified face list.
#
proc Outline \{faces \{t .2\}\} \{
  set flist \{\}
  foreach face $faces \{
    set f [lindex $face 0]
    switch [llength $f] \{
      1 - 2 \{lappend flist $face\}
      3 \{
        if \{$t != 0\} \{
          let (p_0,p_1,p_2) = f
          foreach i \{0 1\} \\
            \{let q_i = p_i + t (p_2 - p_i)\}
          let f = (p_0,p_1,q_1,q_0)
          lappend flist [lreplace $face 0 0 $f]
        \}
      \}
      4 \{
        if \{$t != 0\} \{
          let (p_0,p_1,p_2,p_3) = f
          let P = ((p_0 + p_1) + (p_2 + p_3)) / 4
          foreach i \{0 1 2 3\} \\
            \{let q_i = p_i + t (P - p_i)\}
          foreach i \{0 1 2 3\} j \{1 2 3 0\} \{
            let f = (p_i,p_j,q_j,q_i)
            lappend flist [lreplace $face 0 0 $f]
          \}
        \}
      \}
    \}
  \}
  return $flist
\}

#
#  The slicing routine above never produces
#  just a single point, which we need if we
#  are slicing at a corner first.  In this case,
#  if the height is 0 or 1 (where a single point
#  would occur), move slightly in so that we get
#  a really small slice instead.
#
#  Compute the vertex heights.
#  Compute the intersections with edges and faces.
#  Get the face list that is the cube intersections.
#
Setup \{
  if \{$setD == 0\} \{
    if \{$h == 0\} \{set h .005\} \\
     elseif \{$h == 1\} \{set h .995\}
  \}
  HeightV $D $h
  IntersectE; IntersectF
  set Faces [IntersectC $Cubes]
\}

#
#  The faces have been precomputed
#
Faces \{$Faces\}
Precomputed -faces

#
#  If we are filling the faces and they
#  are not the complete faces, apply the
#  Outline operation.
#
Transform \{if \{filled && s != 1\} \{lApply Outline s\}\}
}
  {always 1 keep}
  {{set w} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {8 {}}
}
