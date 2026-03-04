#############################
#
#  File:     /home/dpvc/tcl/doc/StageManager/Samples/klein/Klein.cs
#  Created:  Tue Nov 23 15:22:40 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Surface Create Klein {
  {Domain \{\{pi/4 w*9pi/4 int(48w)+1\} \{-pi pi 24\}\}

Function \{t u\} \{
  if \{$t < 5*$pi/4\} \{
    let X = ( cos t, a (sin(2t) - 1) / 2, 0)
    let V = (-sin t, a cos(2t), 0)
    let U = B >< Unit(V)
    let (x,y,z) = X + c cos(u) U + c sin(u) B
  \} else \{
    let r = c + a (1 + sin(2t - 3pi))/2
    let (x,y,z) = (cos t, r cos u, r sin u)
  \}
\}

let B = (0,0,1)

ColorFunction NormalizedT \{(t-pi/4)/(2pi)\}

Slider a 0 1 .5
Slider c 0 1 .15
Slider w .15 1}
  {selected 1 none}
  {{::_color::Function NormalizedT} 1 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
  {::sd::Patch 0 1 .25}
}
