#############################
#
#  File:     Development:tcl:doc:CenterStage:Samples:Levels-Part3.cs
#  Created:  Thu Nov 18 10:24:23 Z 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Levels-18 {
  {#
#  This example shows how to slice the domain of
#  a parametric surface and then map that level set
#  onto the surface.
#
#  We use a torus as our surface and allow you
#  to slice it in any direction at any height.
#  If \"Torus Slice\" is checked, the level set
#  will be mapped to the torus in space.
#  If \"Torus Grid\" is checked, the complete torus
#  will be shown as a grid in space.
#


#
#  The windows for the control panel
#
Window controls -rows \{1 1\} -columns 1
Frame top -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows 1 -columns \{1 0 0\}

#
#  The slice direction.  We don't care if it's a
#  unit vector since everything is normalized
#  in the slicing and coloring.
#

TypeIn V \"(1,1,0)\" -evaluate -width 10 \\
  -title \"Slice Direction:\" -in top -at \{0 0\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::DataFromSurface Create Levels-18/Domain-Grid {
  {#
#  This simply displays the grid already
#  computed by the Surface-Domain object it is
#  linked to.
#}
  {always 1 each}
  {{set v} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
  {::sd::Grid 0 0 .25}
}

####################

::class::Levels Create Levels-18/Level-Domain {
  {#
#  This gets us a level set in the domain that 
#  maps to the given height in the given direction.
#  We use a link to the Surface-Domain object
#  and slice it by the value that the function
#  would have at each point in the grid.
#
#  The function F() is inherited from the
#  Surface-Domain object itself.
#

Height F(u,v).V = h -normalize

#
#  Slice at this height
#

Slider h 0 1 .5 -in controls -at \{0 1\} \\
  -title \"Slice at height =\"}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {0 4}
}

####################

::class::DataFromPolyhedron Create Levels-18/Level-Surface {
  {#
#  This maps the Level-Domain onto the torus
#  using the vApply function of the Transform
#  directive.
#

#
#  This function is used to compute F at each
#  vertex of the edges in the Level-Domain.
#  It would have been nice to simply use
#  \{vApply F\} instead, but since F expects
#  two parameters (u and v) but vApply passes
#  the point as a vector not as two coordinates,
#  this wouldn't work.  The \"let\" command does
#  the vector decomposition for us.
#

vproc f \{p\} \{
  let P = F(p)
  return $P
\}

#
#  After mapping the level set onto the torus,
#  it is scaled and moved so that it is in a
#  reasonable relationship to the domain grid.
#

Transform \\
  Translate(.5,.5,.75) \\
  Scale(.25) \\
  \{vApply f\}

#
#  Checkbox to tell if the surface should display
#
CheckBox Show 0 -in top -at \{1 0\} \\
  -title \"Torus Slice\"
ShowMe Show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 0}
}

####################

::class::DataFromSurface Create Levels-18/Surface-Grid {
  {#
#  This simply displays the torus grid when
#  the checkbox is selected.
#

CheckBox Show 0 -in top -at \{2 0\} \\
  -title \"Torus Grid\"
ShowMe Show}
  {always 1 each}
  {{set v} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {::sd::Grid 0 0 .25}
}

####################

::class::Group Create Levels-19 {
  {#
#  This example shows how to slice the domain of
#  a parametric surface and then map that chunk
#  onto the surface.
#
#  We use a torus as our surface and allow you
#  to slice it in any direction at any height.
#  The domain chunk is colored by height in the
#  given direction.  If \"Torus Slice\" is checked,
#  the chunk will be mapped to the torus in space
#  If \"Torus Grid\" is checked, the complete torus
#  will be shown as a grid in space.
#


#
#  The windows for the control panel
#
Window controls -rows \{1 1\} -columns 1
Frame top -in controls -at \{0 0\} \\
  -relief raised -bd 2 -rows 1 -columns \{1 0 0\}

#
#  The slice direction.  We don't care if it's a
#  unit vector since everything is normalized
#  in the slicing and coloring.
#

TypeIn V \"(1,1,0)\" -evaluate -width 10 \\
  -title \"Slice Direction:\" -in top -at \{0 0\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Levels Create Levels-19/Chunk-Domain {
  {#
#  This gets us a chunk of the domain that is
#  below the given height in the given direction.
#  We use a link to the Surface-Domain object
#  and slice it by the value that the function
#  would have at each point in the grid.
#
#  The function F() is inherited from the
#  Surface-Domain object itself.
#

Height F(u,v).V < h -normalize

#
#  Color by height
#
ColorFunction Height \{F(u,v).V\}

#
#  Slice at this height
#

Slider h 0 1 .5 -in controls -at \{0 1\} \\
  -title \"Slice at height =\"}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {1 4}
}

####################

::class::DataFromPolyhedron Create Levels-19/Chunk-Surface {
  {#
#  This maps the Chunk-Domain onto the torus
#  using the vApply function of the Transform
#  directive.
#

#
#  This function is used to compute F at each
#  vertex of the polygons in the Chunk-Domain.
#  It would have been nice to simply use
#  \{vApply F\} instead, but since F expects
#  two parameters (u and v) but vApply passes
#  the point as a vector not as two coordinates,
#  this wouldn't work.  The \"let\" command does
#  the vector decomposition for us.
#

vproc f \{p\} \{
  let P = F(p)
  return $P
\}

#
#  After mapping the domain chunk onto the torus,
#  it is scaled and moved so that it is in a
#  reasonable relationship to the domain grid.
#

Transform \\
  Translate(.5,.5,.75) \\
  Scale(.25) \\
  \{vApply f\}

#
#  Color by height in the given direction
#
ColorFunction Height \{(x,y,z).V\}

#
#  Checkbox to tell if the surface should display
#
CheckBox Show 0 -in top -at \{1 0\} \\
  -title \"Torus Slice\"
ShowMe Show}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
}

####################

::class::DataFromSurface Create Levels-19/Domain-Grid {
  {#
#  This simply displays the grid already
#  computed by the Surface-Domain object it is
#  linked to.
#}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
  {::sd::Grid 0 0 .25}
}

####################

::class::DataFromSurface Create Levels-19/Surface-Grid {
  {#
#  This simply displays the torus grid when
#  the checkbox is selected.
#

CheckBox Show 0 -in top -at \{2 0\} \\
  -title \"Torus Grid\"
ShowMe Show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {::sd::Grid 0 0 .25}
}

####################

::class::Group Create Levels-20 {
  {#
#  This example combines the ideas from the
#  previous two examples into a single
#  demonstration.  You can specify the direction
#  for slicing, and where the slices or chunks
#  should be taken.  The levels are specified 
#  as a list of heights (e.g., \".1 .3 .6\"), or
#  or using the \"Points\" function (e.g.,
#  \"Points((.1,.9),5)\" or \"[Points \{.1 .9\} 5]\").
#  Similarly, the chunks are specified by a list
#  of intervals (e.g., \"(.1,.2) (.3,.4)\") or
#  by the \"Bands\" function (e.g., \"Bands((0,1),3)\"
#  or \"[Bands \{0 1\} 3]\").
#

#
#  The windows for the control panel
#
Window controls -rows \{1 1 1 1\} -columns 1
Frame cbox -in controls -at \{0 3\} -columns \{1 1\} -bd 2

#
#  The slice direction.  We don't care if it's a
#  unit vector since everything is normalized
#  in the slicing and coloring.
#

TypeIn V \"(1,1,0)\" -evaluate -width 10 -titlewidth 16 \\
  -title \"Slice Direction:\" -in controls -at \{0 0\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Levels-20/Domain {
  {#
#  This group contains the chunks and levels.
#  It didn't have to be a group, but it doesn't
#  hurt.
#}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} {}}
}

####################

::class::Levels Create Levels-20/Domain/Chunks {
  {#
#  This gets us a collection of chunks of the
#  domain within the intervals given in the
#  TypeIn.
#
#  The function F() is inherited from the
#  Surface-Domain object itself.
#

Height F(u,v).V within chunks -normalize

#
#  Color by height
#
ColorFunction Height \{F(u,v).V\}

#
#  Chunks at these heights
#

TypeIn chunks \"\" -evaluate -titlewidth 16 \\
  -in controls -at \{0 2\} -title \"Chunks between:\"

#
#  Only show if there are chunks to compute
#
ShowMe \{chunks != \"\"\}}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {2 4}
}

####################

::class::Levels Create Levels-20/Domain/Levels {
  {#
#  This gets us a collection of levels sets in 
#  the domain where the mapping to the torus
#  takes these levels to the given heights.
#  We use a link to the Surface-Domain object
#  and slice it by the value that the function
#  would have at each point in the grid.
#
#  The function F() is inherited from the
#  Surface-Domain object itself.
#

Height F(u,v).V at heights -normalize

#
#  Color by height
#
ColorFunction Height \{F(u,v).V\}

#
#  Slice at these heights
#

TypeIn heights \"\" -evaluate -titlewidth 16\\
  -in controls -at \{0 1\} -title \"Levels at:\"

#
#  Only show if there are levels to compute
#
ShowMe \{heights != \"\"\}}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {3 4}
}

####################

::class::DataFromSurface Create Levels-20/Domain-Grid {
  {#
#  This simply displays the grid already
#  computed by the Surface-Domain object it is
#  linked to.
#}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
  {::sd::Grid 0 0 .25}
}

####################

::class::Group Create Levels-20/Surface {
  {#
#  This maps the domain chunks and levels onto
#  the torus using the vApply function of the
#  Transform directive.
#

#
#  This function is used to compute F at each
#  vertex of the polygons in the Chunk-Domain.
#  It would have been nice to simply use
#  \{vApply F\} instead, but since F expects
#  two parameters (u and v) but vApply passes
#  the point as a vector not as two coordinates,
#  this wouldn't work.  The \"let\" command does
#  the vector decomposition for us.
#

vproc f \{p\} \{
  let P = F(p)
  return $P
\}

#
#  After mapping the domain slices onto the torus,
#  they are scaled and moved so that they are in a
#  reasonable relationship to the domain grid.
#

Transform \\
  Translate(.5,.5,.75) \\
  Scale(.25) \\
  \{vApply f\}

#
#  Checkbox to tell if the surface should display
#
CheckBox Show 0 -in cbox -at \{0 0\} \\
  -title \"Show Torus Slices\"
ShowMe Show

}
  {always 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 4}
}

####################

::class::DataFromPolyhedron Create Levels-20/Surface/Chunks {
  {#
#  (Note that \"V\" and \"chunks\" are inherited from
#  the linked object.)
#

#
#  Color by height in the given direction
#
ColorFunction Height \{(x,y,z).V\}

#
#  Only show if the surface is showing and
#  there are chunks to display
#
ShowMe \{Show && chunks != \"\"\}}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {smooth 1.0 2 1 0 0 0 0 0 0 0 0 1.0 2}
  {{} 2}
}

####################

::class::DataFromPolyhedron Create Levels-20/Surface/Levels {
  {#
#  (Note that \"V\" and \"heights\" are inherited from
#  the linked object.)
#

#
#  Color by height in the given direction
#
ColorFunction Height \{(x,y,z).V\}

#
#  Only show if the surface is showing and
#  there are levels to display
#
ShowMe \{Show && heights != \"\"\}}
  {always 1 each}
  {{::_color::Function Height} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 3 1 0 0 0 0 0 0 0 0 1.0 3}
  {{} 3}
}

####################

::class::DataFromSurface Create Levels-20/Surface-Grid {
  {#
#  This simply displays the torus grid when
#  the checkbox is selected.
#

CheckBox Show 0 -in cbox -at \{1 0\} \\
  -title \"Show Torus Grid\"
ShowMe Show}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 5}
  {::sd::Grid 0 0 .25}
}

####################

::class::Surface Create Surface-Domain {
  {#
#  This is a Surface object that simply is used
#  to make the domain grid (note that the Function
#  directive does nothing but set the u and v
#  values).  It is linked from the Levels objects
#  in the groups above.
#

Domain \{\{0 1 12\} \{0 1 24\}\}
Function \{u v\} \{\}
Axes \{u v\}

#
#  Here we define the equations for a torus.
#  Any object that links to this one will have
#  access to the function F below.
#

#
#  the major and minor radii
#
let a = sqrt(2)
let b = 1

#
#  The mapping from the uv-plane into three-space.
#  The \"args\" parameter is a technicality used
#  to absorb any extra coordinates passed to
#  F when F(p) is performed in the vApply 
#  transformations that map the levels and chunks
#  onto the torus.  For efficiency reasons, 
#  Polyhedron objects in CenterStage always have
#  at least three coordinates even if their Axes
#  directives specify only two, so when \{vApply f\}
#  passes the points to f, they always have three,
#  not two, coordinates.  The \"args\" parameter
#  will absorb this extra parameter in this
#  case, and will be an empty list when only two
#  coordinates are given.
#
vproc F \{u v args\} \{
  variable a; variable b
  let (u,v) = (2 pi u, 2 pi v)
  let P = \\
    ((a + b cos u) cos v, \\
     (a + b cos u) sin v, \\
     b sin u)
  return $P
\}
}
  {selected 1 each}
  {{set v} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {4 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Surface Create Surface-Grid {
  {#
#  This object simply maps the domain grid
#  onto the torus.  We have access to the F()
#  function because we have explicitly linked
#  this Surface object (which doesn't normally
#  require a link) to the Surface-Domain object.
#

Domain \{\{0 1 12\} \{0 1 24\}\}

Function \{u v\} \{
  let (x,y,z) = F(u,v)
\}

#
#  Scale and translate the resulting torus
#  so that it appears above the domain.
#
Transform Translate(.5,.5,.75) Scale(.25)}
  {selected 1 each}
  {{set v} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {5 4}
  {::sd::Grid 0 0 .25}
}
