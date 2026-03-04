#############################
#
#  File:     /home/idol/u0/faculty/math/dpvc/tcl/doc/CenterStage/Samples/MorePolyhedra.cs
#  Created:  Sat Oct 16 14:25:04 EDT 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Polyhedron Create Polyhedron-7 {
  {#
#  Here we have an icosahedron whose faces can
#  be shrunken down toward their centers.  A
#  slider controls how face they shrink.
#

let t = (sqrt(5)-1)/2

Vertices \{
  a0: (1,0,t)  a1: (1,0,-t)
  b0: (-1,0,t) b1: (-1,0,-t)
  c0: (t,1,0)  c1: (-t,1,0)
  d0: (t,-1,0) d1: (-t,-1,0)
  e0: (0,t,1)  e1: (0,-t,1)
  f0: (0,t,-1) f1: (0,-t,-1)
\}

Faces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}
 \{a0 a1 c0\} \{a0 d0 a1\}
 \{b0 b1 d1\} \{b0 c1 b1\}
 \{c0 c1 e0\} \{c0 f0 c1\}
 \{d0 d1 f1\} \{d0 e1 d1\}
 \{e0 e1 a0\} \{e0 b0 e1\}
 \{f0 f1 b1\} \{f0 a1 f1\}
\}

#
#  We calculate the center of the face
#  and then move each vertex the given amount
#  toward this center.  The resulting new
#  face is returned
#

proc Shrink \{face s\} \{
  if \{$s == 0\} \{return $face\}
  let (p_0,p_1,p_2) = face
  let P = (p_0 + p_1 + p_2) / 3
  if \{$s == 1\} \{return [list $P]\}
  foreach i \{0 1 2\} \{let p_i = p_i + s (P - p_i)\}
  let face = (p_0,p_1,p_2)
  return $face
\}

#
#  Here we apply the \"Shrink\" function to each
#  face in the polyhedron via the \"fApply\"
#  transform (see the documentation for more
#  details on transformations).
#
Transform \{fApply Shrink s\}

Slider s 0 1 -title \"Shrink faces by:\"}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-8 {
  {#
#  This icosahedron has its faces moved along
#  their normal directions by an amount given
#  by a slider.  If the slider is negative, then
#  the faces are moved in to the center of the
#  icosahedron, causing interesting intersections.
#

let t = (sqrt(5)-1)/2

Vertices \{
  a0: (1,0,t)  a1: (1,0,-t)
  b0: (-1,0,t) b1: (-1,0,-t)
  c0: (t,1,0)  c1: (-t,1,0)
  d0: (t,-1,0) d1: (-t,-1,0)
  e0: (0,t,1)  e1: (0,-t,1)
  f0: (0,t,-1) f1: (0,-t,-1)
\}

Faces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}
 \{a0 a1 c0\} \{a0 d0 a1\}
 \{b0 b1 d1\} \{b0 c1 b1\}
 \{c0 c1 e0\} \{c0 f0 c1\}
 \{d0 d1 f1\} \{d0 e1 d1\}
 \{e0 e1 a0\} \{e0 b0 e1\}
 \{f0 f1 b1\} \{f0 a1 f1\}
\}

#
#  Here we compute the normal direction to the
#  face and offset each vertex by the given
#  amount in that direction.  A more sophisticated
#  routine could handle faces that aren't triangles.
#
proc Offset \{face s\} \{
  if \{$s == 0\} \{return $face\}
  let (p_0,p_1,p_2) = face
  let N = (p_1 - p_0) >< (p_2 - p_0)
  foreach i \{0 1 2\} \{let p_i = p_i + s N\}
  let face = (p_0,p_1,p_2)
  return $face
\}

#
#  As in the previous example, the function is
#  applied to each face of the polyhedron via
#  the \"fApply\" transformation.
#
Transform \{fApply Offset s\}

Slider s -1 1 0 -title \"Offset faces by:\"}
  {selected 1 keep}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 1 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-9 {
  {#
#  Here the icosahedron can have the centers of
#  its faces removed.  Hoe much is cut out  is
#  again controlled by a slider.
#

let t = (sqrt(5)-1)/2

Vertices \{
  a0: (1,0,t)  a1: (1,0,-t)
  b0: (-1,0,t) b1: (-1,0,-t)
  c0: (t,1,0)  c1: (-t,1,0)
  d0: (t,-1,0) d1: (-t,-1,0)
  e0: (0,t,1)  e1: (0,-t,1)
  f0: (0,t,-1) f1: (0,-t,-1)
\}

Faces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}
 \{a0 a1 c0\} \{a0 d0 a1\}
 \{b0 b1 d1\} \{b0 c1 b1\}
 \{c0 c1 e0\} \{c0 f0 c1\}
 \{d0 d1 f1\} \{d0 e1 d1\}
 \{e0 e1 a0\} \{e0 b0 e1\}
 \{f0 f1 b1\} \{f0 a1 f1\}

 #
 # we add the edges is separately, since
 # we don't want to see the edges of the
 # faces used to slice the triangles
 #
 \{
  \{a0 c0\} \{c0 e0\} \{a0 e0\}
  \{a1 f0\} \{a1 c0\} \{c0 f0\}
  \{a0 e1\} \{a0 d0\} \{d0 e1\}
  \{a1 d0\} \{a1 f1\} \{d0 f1\}
  \{b1 c1\} \{b1 f0\} \{c1 f0\}
  \{b0 e0\} \{b0 c1\} \{c1 e0\}
  \{b1 f1\} \{b1 d1\} \{d1 f1\}
  \{b0 d1\} \{b0 e1\} \{d1 e1\}
  \{a0 a1\} \{b0 b1\} \{c0 c1\}
  \{d0 d1\} \{e0 e1\} \{f0 f1\}
 \} <- \{color \{0 0 0\}\}
\}

#
#  The face list is a list of lists, where each
#  entry in the list is another list consisting
#  of the list of vertices of the face as its
#  first element, and other data following.
#  For each face in the list, we check if
#  the face is a triangle and if not, simply
#  add the face back into the list.  Otherwise,
#  we find the center of the face and compute
#  the vertices of the removed chunk.  Then
#  we add three new quadrilatorals, one along
#  each edge of the original face.
#
proc Outline \{faces \{t .2\}\} \{
  if \{$t == 1\} \{return $faces\}
  set flist \{\}
  foreach face $faces \{
    if \{[llength [lindex $face 0]] != 3\} \{
      lappend flist $face
    \} elseif \{$t != 0\} \{
      let (p_0,p_1,p_2) = face@0
      let P = (p_0 + p_1 + p_2) / 3
      foreach i \{0 1 2\} \{let q_i = p_i + t (P - p_i)\}
      foreach i \{0 1 2\} \{
        let j = (i+1) % 3
        let f = (p_i,p_j,q_j,q_i)
        lappend flist [lreplace $face 0 0 $f]
      \}
    \}
  \}
  return $flist
\}

#
#  Since our routine changes the number of
#  faces in the object, we must use the \"lApply\"
#  transform to modify the complete face list.
#

Transform \{lApply Outline s\}

Slider s 0 1 1 -title \"Portion of face to show:\"
}
  {selected 1 each}
  {{::_color::Function Normal} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-10 {
  {#
#  This sample shows how to subdivide every
#  face of a polyhedron into a larger number of
#  sub-faces.  You might want to do this if
#  you want to color the object by a non-linear
#  function, or if you plan to slice the
#  object by a non-linear function and want a
#  more precise cut.
#

#
#  The icosahedron again
#
let t = (sqrt(5)-1)/2

Vertices \{
  a0: (1,0,t)  a1: (1,0,-t)
  b0: (-1,0,t) b1: (-1,0,-t)
  c0: (t,1,0)  c1: (-t,1,0)
  d0: (t,-1,0) d1: (-t,-1,0)
  e0: (0,t,1)  e1: (0,-t,1)
  f0: (0,t,-1) f1: (0,-t,-1)
\}

Faces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}
 \{a0 a1 c0\} \{a0 d0 a1\}
 \{b0 b1 d1\} \{b0 c1 b1\}
 \{c0 c1 e0\} \{c0 f0 c1\}
 \{d0 d1 f1\} \{d0 e1 d1\}
 \{e0 e1 a0\} \{e0 b0 e1\}
 \{f0 f1 b1\} \{f0 a1 f1\}
\}

#
#  This function cuts each face into subfaces.
#  It goes through the list of faces and
#  divides each in a way appropriate for its
#  number of veritces.
#
#  (This should really be made part of the
#  Polyhedron class somewhere.)
#
proc Dice \{faces \{n 1\}\} \{
  if \{$n <= 1\} \{return $faces\}
  set flist \{\}
  foreach face $faces \{
    set f [lindex $face 0]
    switch [llength $f] \{
      1 \{lappend flist $face\}
      2 \{DiceEdge $f $face\}
      3 \{DiceTriangle $f $face\}
      default \{DicePolygon $f $face\}
    \}
  \}
  return $flist
\}

#
#  For an edge, we find its endpoints and
#  the vector between them, then loop n times
#  while adding a small segment to the face list
#  at each step.
#
proc DiceEdge \{f face\} \{
  upvar flist flist  n n
  let (p0,p1) = f; let u = p1 - p0; set q0 $p0
  for \{set i 1\} \{$i <= $n\} \{incr i\} \{
    let q1 = p0 + i u / n
    let f = (q0,q1); set q0 $q1
    lappend flist [lreplace $face 0 0 $f]
  \}
\}

#
#  For a triangle, we get the corners and
#  vectors along two edges.  Then we make a
#  (triangular) array of the interpolated points
#  in within the triangle.
#
#  Then we create the subtriangles using this
#  array of points.  There are two families of
#  triangles so there are two sets of loops.
#
proc DiceTriangle \{f face\} \{
  upvar flist flist  n n
  let (p0,p1,p2) = f
  let u1 = p1 - p0; let u2 = p2 - p0
  for \{set j 0\} \{$j <= $n\} \{incr j\} \{
    for \{set i 0\} \{$i <= $n - $j\} \{incr i\} \\
      \{let q_(i,j) = p0 + (i u1 + j u2) / n\}
  \}
  for \{set j 0\} \{$j < $n\} \{incr j\} \{
    for \{set i $j\} \{$i >= 0\} \{incr i -1\} \{
      let f = (q_(i,j-i),q_(i+1,j-i),q_(i,j-i+1))
      lappend flist [lreplace $face 0 0 $f]
    \}
  \}
  for \{set j 1\} \{$j < $n\} \{incr j\} \{
    for \{set i $j\} \{$i > 0\} \{incr i -1\} \{
      let f = (q_(i,j-i),q_(i,j-i+1),q_(i-1,j-i+1))
      lappend flist [lreplace $face 0 0 $f]
    \}
  \}
\}

#
#  For anything larger than a triangle, we break
#  the polygon into subtriangles first, then
#  subdivide each.  The results may be ugly, but
#  it works as long as the polygon is convex.
#
proc DicePolygon \{f face\} \{
  upvar flist flist  n n
  set m [llength $f]
  for \{set i 1\} \{$i < $m-1\} \{incr i\} \{
    let ff = (f@0,f@i,f@(i+1))
    DiceTriangle $ff $face
  \}
\}

#
#  Since our routine changes the number of
#  faces in the object, we must use the \"lApply\"
#  transform to modify the complete face list.
#

Transform \{lApply Dice n\}

Slider n 1 6 -resolution 1 -title \"Subdivisions:\"
}
  {selected 1 each}
  {{::_color::Function RGB=XYZ} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Polyhedron Create Polyhedron-11 {
  {#
#  This sample shows how to make spherical
#  polygons and segments.  The idea is similar
#  to the previous dicing example.  In fact, 
#  we could have simply normalized all the
#  reults of that dicing operation so that the
#  vectors were length one, but this would
#  not have given very uniform results; e.g.,
#  if the endpoints of a edge lie on the sphere
#  and we subdivie then push out to the sphere, 
#  the segments from the center of the edge
#  will be longer than the ones near the endpoints.
#  To overcome this, we subdivie the angle between
#  the vectors from the origin to the endpoints
#  and make small segments based on equal-sized
#  angles.
#

#
#  The icosahedron again
#
let t = (sqrt(5)-1)/2

Vertices \{
  a0: (1,0,t)  a1: (1,0,-t)
  b0: (-1,0,t) b1: (-1,0,-t)
  c0: (t,1,0)  c1: (-t,1,0)
  d0: (t,-1,0) d1: (-t,-1,0)
  e0: (0,t,1)  e1: (0,-t,1)
  f0: (0,t,-1) f1: (0,-t,-1)
\}

Faces \{
 \{a0 c0 e0\} \{a1 f0 c0\}
 \{a0 e1 d0\} \{a1 d0 f1\}
 \{b1 c1 f0\} \{b0 e0 c1\}
 \{b1 f1 d1\} \{b0 d1 e1\}
 \{a0 a1 c0\} \{a0 d0 a1\}
 \{b0 b1 d1\} \{b0 c1 b1\}
 \{c0 c1 e0\} \{c0 f0 c1\}
 \{d0 d1 f1\} \{d0 e1 d1\}
 \{e0 e1 a0\} \{e0 b0 e1\}
 \{f0 f1 b1\} \{f0 a1 f1\}
\}


#
#  This function cuts each face into subfaces.
#  It goes through the list of faces and
#  first normalizes all the vertices, then
#  divides each face in a way appropriate for its
#  number of veritces.
#
#  (This should really be made part of the
#  Polyhedron class somewhere.)
#
proc SphericalDice \{faces \{n 1\}\} \{
  if \{$n <= 1\} \{return $faces\}
  set flist \{\}
  foreach face $faces \{
    set f \{\}
    foreach v [lindex $face 0] \\
      \{lappend f [Math Unit(v)]\}
    switch [llength $f] \{
      1 \{lappend flist $face\}
      2 \{SphericalDiceEdge $f $face\}
      3 \{SphericalDiceTriangle $f $face\}
      default \{SphericalDicePolygon $f $face\}
    \}
  \}
  return $flist
\}

#
#  For an edge, we find its endpoints and
#  the vector between them, and form an orthonormal
#  basis (p0 and u) in the plane containing the
#  edge and the origin.  The angle we need to divide
#  is m, and we loop n times while adding a small
#  spherical segment to the face list at each step.
#
proc SphericalDiceEdge \{f face\} \{
  upvar flist flist  n n
  let (p0,p1) = f; set q0 $p0
  let u = Unit((p0 >< p1) >< p0)
  let m = acos(p0.p1)
  for \{set i 1\} \{$i <= $n\} \{incr i\} \{
    let q1 = cos(i m / n) p0 + sin(i m / n) u
    let f = (q0,q1); set q0 $q1
    lappend flist [lreplace $face 0 0 $f]
  \}
\}

#
#  For a triangle, we get the corners and
#  vectors along two edges.  Then we make a
#  (triangular) array of the interpolated points
#  in within the triangle.  To do this, we
#  locate points along the edges (as in 
#  SphericalDiceEdges above) and then subdivide
#  the great-circle arc between these points.
#
#  Then we create the subtriangles using this
#  array of points.  There are two families of
#  triangles so there are two sets of loops.
#
proc SphericalDiceTriangle \{f face\} \{
  upvar flist flist  n n
  let (p0,p1,p2) = f
  let u1 = Unit((p0 >< p1) >< p0)
  let u2 = Unit((p0 >< p2) >< p0)
  let (m1,m2) = (acos(p0.p1),acos(p0.p2))
  let q_(0,0) = p0
  for \{set j 1\} \{$j <= $n\} \{incr j\} \{
    let q1 = cos(j m1 / n) p0 + sin(j m1 / n) u1
    let q2 = cos(j m2 / n) p0 + sin(j m2 / n) u2
    let u = Unit((q1 >< q2) >< q1)
    let m = acos(q1.q2)
    for \{set i 0\} \{$i <= $j\} \{incr i\} \\
      \{let q_(i,j-i) = cos(i m / j) q1 + sin(i m / j) u\}
  \}
  for \{set j 0\} \{$j < $n\} \{incr j\} \{
    for \{set i $j\} \{$i >= 0\} \{incr i -1\} \{
      let f = (q_(i,j-i),q_(i+1,j-i),q_(i,j-i+1))
      lappend flist [lreplace $face 0 0 $f]
    \}
  \}
  for \{set j 1\} \{$j < $n\} \{incr j\} \{
    for \{set i $j\} \{$i > 0\} \{incr i -1\} \{
      let f = (q_(i,j-i),q_(i,j-i+1),q_(i-1,j-i+1))
      lappend flist [lreplace $face 0 0 $f]
    \}
  \}
\}

#
#  For anything larger than a triangle, we break
#  the polygon into subtriangles first, then
#  subdivide each.  The results may be ugly, but
#  it works as long as the polygon is convex.
#
proc SphericalDicePolygon \{f face\} \{
  upvar flist flist  n n
  set m [llength $f]
  for \{set i 1\} \{$i < $m-1\} \{incr i\} \{
    let ff = (f@0,f@i,f@(i+1))
    SphericalDiceTriangle $ff $face
  \}
\}

#
#  Since our routine changes the number of
#  faces in the object, we must use the \"lApply\"
#  transform to modify the complete face list.
#

Transform \{lApply SphericalDice n\}

Slider n 1 6 -resolution 1 -title \"Subdivisions:\"
}
  {selected 1 each}
  {{::_color::Function RGB=XYZ} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}
