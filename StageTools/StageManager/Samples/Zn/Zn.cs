#############################
#
#  File:     /home/dpvc/tcl/doc/StageManager/Samples/Zn/Zn.cs
#  Created:  Tue Nov 23 17:04:16 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Polyhedron Create Hypercube {
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
\}

Axes \{x y u v\}}
  {selected 1 keep}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} {}}
}

####################

::class::Surface Create Zn {
  {Domain \{\{0 1 10\} \{0 2pi 16n\}\}

Function \{r t\} \{
  let Z = (x,y) = (r cos t, r sin t)
  let (u,v) = Z^n
\}

Slider n 1 5 2 -resolution 1

Axes \{x y u v\}}
  {selected 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 1 .25}
}
