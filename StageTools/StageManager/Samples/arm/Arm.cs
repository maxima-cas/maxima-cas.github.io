#############################
#
#  File:     /home/dpvc/tcl/doc/StageManager/Samples/arm/Arm.cs
#  Created:  Tue Nov 23 15:18:14 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Surface Create Arm1 {
  {Domain \{\{0 2pi 10\} \{0 1 1\}\}

Function \{u v\} \{
  let r = r1 (1-v) + r2 v
  let (x,y,z) = (r cos u, r sin u, h v)
\}

Slider h 0 5 2
Slider r1 0 1 .3
Slider r2 0 1 .2}
  {selected 1 each}
  {{ list 0 1 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 0 .25}
}

####################

::class::Surface Create Arm2 {
  {Domain \{\{0 2pi 10\} \{0 1 1\}\}

Function \{u v\} \{
  let r = r1 (1-v) + r2 v
  let (x,y,z) = (r cos u, r sin u, h v)
\}

Slider h 0 5 1.5
Slider r1 0 1 .2
Slider r2 0 1 .12}
  {selected 1 each}
  {{ list 0 1 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 0 .25}
}

####################

::class::Surface Create Claw {
  {Domain \{\{0 2pi 10\} \{0 1 10\}\}

Function \{u v\} \{
  let r = r1 (1-v) + r2 v
  let (x,y,z) = (r cos u, r (sin u - sin(pi v)), h v)
\}

Slider h 0 1 .5
Slider r1 0 1 .1
Slider r2 0 1 .07}
  {selected 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 1 0 .25}
}
