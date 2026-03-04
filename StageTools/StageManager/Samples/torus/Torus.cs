#############################
#
#  File:     /home/dpvc/tcl/doc/StageManager/Samples/torus/Torus.cs
#  Created:  Tue Nov 23 17:05:34 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Surface Create Torus {
  {Domain \{\{-pi pi 24\} \{-pi pi 12\}\}

Function \{u v\} \{
  let (x,y,z) = \\
    ((a + b cos v) cos u, \\
     (a + b cos v) sin u, \\
     b sin v)
\}

Slider a 0 5 sqrt(2)
Slider b 0 5 1}
  {selected 1 each}
  {{set u} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 1 .25}
}
