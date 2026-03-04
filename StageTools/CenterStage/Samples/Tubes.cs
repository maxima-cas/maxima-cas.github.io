#############################
#
#  File:     /home/dpvc/tcl/doc/CenterStage/Samples/Tubes.cs
#  Created:  Fri Nov 12 10:52:09 EST 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Tube-1 {
  {#
#  A tube around a curve (the tube is shown
#  as bands so that the curve can be seen)
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Tube-1/Curve {
  {Domain \{-1 1 25\}

Function \{t\} \{
  let (x,y,z) = (t,t^2,t^3)
\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {0 {}}
  {::cd::Solid}
}

####################

::class::Tube Create Tube-1/Tube {
  {Domain \{\{-pi pi 8\} \{Inherit\}\}

Radius .2

Tube \{theta\} \{cos(theta) sin(theta)\}}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 0}
  {::sd::BandsU 1 0 .25}
}

####################

::class::Group Create Tube-2 {
  {#
#  A torus as a tube around a circle.  Not
#  a very efficient way to make a torus, but it
#  works.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Tube-2/Curve {
  {Domain \{-pi pi 32\}

Function \{t\} \{
  let (x,y) = (cos t, sin t)
\}}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {1 {}}
  {::cd::Solid}
}

####################

::class::Tube Create Tube-2/Tube {
  {Domain \{\{-pi pi 12\} \{Inherit\}\}

Radius .7

Tube \{theta\} \{cos(theta) sin(theta)\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Tube-3 {
  {#
#  A bumpy torus where you can select
#  the number of bumps.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Tube-3/Curve {
  {Domain \{-pi pi 32\}

Function \{t\} \{
  let (x,y) = (cos t, sin t)
\}}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {2 {}}
  {::cd::Solid}
}

####################

::class::Tube Create Tube-3/Tube {
  {#
#  We compute the number of divisions to
#  use based on the number of bumps.
#
Domain \{\{-pi pi 12\} \{-pi pi Max(24,8n)\}\}

#
#  Here the radius depends on the position
#  along the curve.
#
Radius \{(2 + sin(n t))/7\}

Tube \{theta\} \{cos(theta) sin(theta)\}

Slider n 0 8 3 -resolution 1 \\
  -title \"Number of bulges:\" -simpletitle}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 2}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Tube-4 {
  {#
#  A torus built over a bumpy circle.  Note
#  how as the number of bumps increases, 
#  the Frenet frame twists more and more
#  (the torsion increases).
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Tube-4/Curve {
  {Domain \{-pi pi 32\}

Function \{t\} \{
  let (x,y,z) = (cos t, sin t, sin(n t)/5)
\}

Slider n 0 4 2 -resolution 1 \\
  -title \"Number of bumps:\" -simpletitle}
  {selected 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {3 {}}
  {::cd::Solid}
}

####################

::class::Tube Create Tube-4/Tube {
  {Domain \{\{-pi pi 12\} \{-pi pi 64\}\}

Radius .2

Tube \{theta\} \{cos(theta) sin(theta)\}
}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 3}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Tube-5 {
  {#
#  This examples shows a nested set of
#  links.  It has a surface (torus)
#  together with a curve on that surface
#  (a torus knot) and a tube around that
#  curve (to make it more visible).
#

Window controls -rows \{1 1 1 1 1\} -columns 1
Frame toprow -in controls -at \{0 0\} -columns \{0 1 0\} \\
  -relief raised -bd 2}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Tube-5/Knot {
  {#
#  This is a (p,q)-curve on the torus
#  (it goes around one dircetion p times
#  the other direction q times).
#

#
#  The number of divisions to use is
#  determined by the size of p and q
#
Domain \{-pi pi Max(32,12(p+q))\}

Function \{t\} \{
  let (x,y) = (p t,q t)
\}

Slider p 0 5 1 -resolution 1 -title \"(Knot) p:\" \\
  -in controls -at \{0 1\}
Slider q 0 5 0 -resolution 1 -title \"(Knot) q:\" \\
  -in controls -at \{0 2\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {5 4}
  {::cd::Solid}
}

####################

::class::Surface Create Tube-5/Proto-Torus {
  {#
#  This torus is never shown.  In order to make
#  chaning the domain style not cause the knot
#  to be recomputed, we tie both the knot and the
#  shown torus to this one.  
#

Domain \{\{-pi pi 12\} \{-pi pi 24\}\}

Function \{u v\} \{
  let (x,y,z) = (\\
    (a + b cos(u)) cos(v), \\
    (a + b cos(u)) sin(v),\\
    b sin(u) \\
  )
\}

#
#  The radii of the circles that form
#  the torus
#

Slider a 0 3 sqrt(2) -title \"(Torus) large radius:\" \\
  -in controls -at \{0 3\}
Slider b 0 3 1 -title \"(Torus) small radius:\" \\
  -in controls -at \{0 4\}
}
  {hide 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {4 {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::SurfaceNewDomain Create Tube-5/Torus {
  {#
#  This is the torus that is actually shown.
#  Changes in the PopUp menu below will not cause
#  the Knot to be recomputed.
#

Domain \{\{-pi pi 12\} \{-pi pi 24\} $dtype\}

#
#  the domain style is selected from
#  one of these forms
#
PopUp dtype \{Solid Grid Bands None\} \\
  -values \{Patch Grid BandsU None\} \\
  -title \"Torus:\" -in toprow -at \{2 0\}

#
#  Don't show the torus if \"None\" is selected
#
ShowMe \{dtype != \"None\"\}}
  {always 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
  {::sd::Patch 1 1 .25}
}

####################

::class::Tube Create Tube-5/Tube {
  {#
#  Put a tube around the torus knot
#
Domain \{\{-pi pi 6\} \{Inherit\}\}

Radius .125

Tube \{theta\} \{cos(theta) sin(theta)\}

CheckBox Show 0 -title \"Show Tube around Knot\" -in toprow -at \{0 0\}
ShowMe Show}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Tube-6 {
  {#
#  This examples is almost the same as the previous
#  one except that the torus is handled differently.
#  In the previous example, the torus data was
#  recomputed every time the domain type changed.
#  In this case, we use three separate objects
#  all linked to the proto-torus, so the data is
#  computed only once for the torus and switches
#  between domain style can be faster.  Also, the
#  characteristics (line width, edges showing) can
#  change from type to type since there are
#  separate objects involved, each with its own
#  characteristics.
#

Window controls -rows \{1 1 1 1 1\} -columns 1
Frame toprow -in controls -at \{0 0\} -columns \{0 1 0\} \\
  -relief raised -bd 2}
  {selected 1 keep}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::CurveOnSurface Create Tube-6/Knot {
  {#
#  This is a (p,q)-curve on the torus
#  (it goes around one dircetion p times
#  the other direction q times).
#

#
#  The number of divisions to use is
#  determined by the size of p and q
#
Domain \{-pi pi Max(32,12(p+q))\}

Function \{t\} \{
  let (x,y) = (p t,q t)
\}

Slider p 0 5 1 -resolution 1 -title \"(Knot) p:\" \\
  -in controls -at \{0 1\}
Slider q 0 5 0 -resolution 1 -title \"(Knot) q:\" \\
  -in controls -at \{0 2\}
}
  {always 1 each}
  {{ list 1 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 4 1 0 0 0 0 0 0 0 0 1.0 4}
  {7 6}
  {::cd::Solid}
}

####################

::class::Surface Create Tube-6/Proto-Torus {
  {#
#  This torus is never shown.  In order to make
#  chaning the domain style not cause the knot
#  to be recomputed, we tie both the knot and the
#  shown torus to this one.  
#

Domain \{\{-pi pi 12\} \{-pi pi 24\}\}

Function \{u v\} \{
  let (x,y,z) = (\\
    (a + b cos(u)) cos(v), \\
    (a + b cos(u)) sin(v),\\
    b sin(u) \\
  )
\}

#
#  The radii of the circles that form
#  the torus
#

Slider a 0 3 sqrt(2) -title \"(Torus) large radius:\" \\
  -in controls -at \{0 3\}
Slider b 0 3 1 -title \"(Torus) small radius:\" \\
  -in controls -at \{0 4\}
}
  {hide 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {6 {}}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Tube-6/Torus {
  {#
#  The subobjects of this group are all
#  DataFromSurface objects, which means they
#  all use that data in Proto-Torus, but
#  simply display it differently.  This makes
#  switching domain styles faster, and since
#  there are separate objects for each style,
#  they can change characteristics like line
#  width, edges showing, shading smooth or flat,
#  etc.
#

#
#  the domain style is selected from
#  one of these forms
#
PopUp dtype \{Solid Grid Bands None\} \\
  -title \"Torus:\" -in toprow -at \{2 0\}

#
#  Don't show the torus if \"None\" is selected
#
ShowMe \{dtype != \"None\"\}}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromSurface Create Tube-6/Torus/Bands {
  {ShowMe \{dtype == \"Bands\"\}}
  {always 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 6}
  {::sd::BandsU 1 1 .25}
}

####################

::class::DataFromSurface Create Tube-6/Torus/Grid {
  {ShowMe \{dtype == \"Grid\"\}}
  {always 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 6}
  {::sd::Grid 1 1 .25}
}

####################

::class::DataFromSurface Create Tube-6/Torus/Solid {
  {ShowMe \{dtype == \"Solid\"\}}
  {always 1 each}
  {{set v} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 6}
  {::sd::Patch 1 1 .25}
}

####################

::class::Tube Create Tube-6/Tube {
  {#
#  Put a tube around the torus knot
#
Domain \{\{-pi pi 6\} \{Inherit\}\}

Radius .125

Tube \{theta\} \{cos(theta) sin(theta)\}

CheckBox Show 0 -title \"Show Tube around Knot\" -in toprow -at \{0 0\}
ShowMe Show}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 7}
  {::sd::Patch 1 1 .25}
}

####################

::class::Group Create Tube-7 {
  {#
#  This is Banchoff's version of the
#  Klein bottle that is formed by moving
#  a figure-8 aournd a circle while 
#  rotating the figure-8 by 180 degrees
#  so that its top attaches to its bottom
#  when it comes back around and meets
#  itself.
#
#  It is interesting to view this surface with
#  the domain set to Bands in the theta direction.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Curve Create Tube-7/Circle {
  {Domain \{-pi pi 32\}

Function \{t\} \{
  let (x,y,z) = (cos t, sin t,0)
\}}
  {selected 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {8 {}}
  {::cd::Solid}
}

####################

::class::Tube Create Tube-7/Klein-Bottle {
  {Domain \{\{-pi pi 18\} \{Inherit\}\}

Radius .2

#
#  Here the tube function depends on the
#  position along the curve.  The XY function
#  returns a rotation matrix in the xy-plane.
#

Tube \{theta t\} \\
  \{XY(t/2) * (2cos(theta),sin(2theta),0)\}}
  {always 1 each}
  {{set t} 1 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 1 0 0 0 0 0 0 0 1.0 1}
  {{} 8}
  {::sd::BandsU 1 0 .25}
}
