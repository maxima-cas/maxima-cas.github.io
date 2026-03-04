#############################
#
#  File:     Development:tcl:doc:CenterStage:Samples:Miscellaneous.cs
#  Created:  Thu Nov 18 11:01:27 Z 1999
#  By:       CenterStage v3.1
#

::cs::File Version 3.1


####################

::class::Group Create Misc-1 {
  {#
#  This example shows how to put a bounding box
#  around a surface (or any other object).  As
#  the surface changes in respons to the slider,
#  the bounding box also updates itself.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::BoundingBox Create Misc-1/BoundingBox {
  {#
#  There's not much to a bounding box object.
#  You can, however, specify a little padding
#  that expands (or contracts) the box.
#
Padding .1

#
#  You could specify a different padding in each
#  direction via
#
#    Padding \{.1 .2 -.3\}
#}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 1}
}

####################

::class::Surface Create Misc-1/Surface {
  {#
#  A surface whose shape depends on a slider
#

Domain \{\{-1 1 10\} \{-1 1 10\}\}

Function \{u v\} \{
  let (x,y,z) = (u, v, u (v+a))
\}

Slider a -1 1 0}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {1 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Misc-2 {
  {#
#  This examples shows how to use a bounding
#  box to create a slicing plane that is normalized
#  to the size of the sliced object.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::BoundingBox Create Misc-2/BoundingBox {
  {#
#  This is just the bounding box.  We show it
#  in this example, but you could set OBJECT/SHOW
#  to NEVER in order to get the computation from
#  the bounding box without displaying it.
#}
  {always 1 each}
  {{ list 0 0 0} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {0 2}
}

####################

::class::Polyhedron Create Misc-2/Plane {
  {#
#  We create the face for this plane in the routine
#  below:
#
Faces \{[Slice $h]\}

#
#  First we get the bounding box from the 
#  BoundingBox object (to which this one is
#  linked) and break that into its components.
#  We then compute the actual height of the
#  slicing plane based on the bounding box's
#  vertical dimension.  Finally, we construct
#  a face from that height using the x and y
#  dimensions of the bounding box.  We pass
#  back the list of faces that contains just
#  this one face.
#

proc Slice \{h\} \{
  set BBox [Object BBox]
  let ((xm,ym,zm),(xM,yM,zM)) = BBox
  let k = h zM + (1-h) zm
  let F = ((xm,ym,k),(xm,yM,k),(xM,yM,k),(xM,ym,k))
  return [list $F]
\}

#
#  The normalized height (within the bounding box)
#  of the slicing plane.
#
Slider h 0 1}
  {always 1 each}
  {{ list 1 0 1} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} 0}
}

####################

::class::Surface Create Misc-2/Surface {
  {#
#  A surface whose shape depends on a slider.
#

Domain \{\{-1 1 10\} \{-1 1 10\}\}

Function \{u v\} \{
  let (x,y,z) = (u, v, u (v+a))
\}

Slider a -1 1 0}
  {always 1 each}
  {{set z} 0 1 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {2 {}}
  {::sd::Patch 0 0 .25}
}

####################

::class::Group Create Misc-3 {
  {#
#  This example shows how to create a simple
#  help screen that can show several pages
#  of scrollable information.
#
#  Click the HELP button to get the help screen.
#}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Misc-3/Help {
  {#
#  This is a hidden object that simply serves as 
#  a storage area for the help text and window.
#  Its OBJET/SHOW menu is set to NEVER so it
#  will never be computed or shown.  But its
#  widgets are still available when the
#  parent object is selected.  Thus its HELP
#  button can still be pressed, and the help
#  window can still display.
#

#
#  Here we create the help window, and its
#  associated widgets.
#

#
#  Only the text area will grow when the
#  window is resized.
#
Window help -rows \{0 1 0\} -columns 1 -disabled

#
#  We want the menu centered, so we put it
#  in a frame.  (The frame will fill up the
#  column, but since we don't specify -column 1
#  for this frame, the menu will not.)
#
Frame hmenu -in help -at \{0 0\} -bd 2
#
#  The button box at the bottom has some extra
#  columns for spacing.
#
Frame hbox -columns \{1 1 1 1 1 1\} \\
  -in help -at \{0 2\} -bd 4

#
#  This menu specifies the help topics.
#  When it changes, it sets the help text to
#  the appropriate value.
#
PopUp hChoice \{Topic1 Topic2 Topic3\} \\
  -title \"Get help on\" -values \{1 2 3\} \\
  -command \{hSet $hChoice\}\\
  -in hmenu -at \{0 0\}

#
#  This shows the current help text in a large
#  text window with a scroll bar and no title.
#
TypeOut hShow -in help -at \{0 1\} \\
  -title \" \" -lines 15 -width 40

#
#  The Next and Previous buttons call a routine
#  to increment or decrement the current help
#  topic.
#
Button hPrev -in hbox -at \{1 0\} -title \"Prev\" \\
  -command \{hShow -1\}
Button hNext -in hbox -at \{2 0\} -title \"Next\" \\
  -command \{hShow 1\}

#
#  We test to make sure we don't go off the
#  end of the help-test array, and then
#  the the menu to display the proper text.
#  The PopUp willl handle changing the text.
#
proc hShow \{n\} \{
  variables hText hChoice
  set m [llength [array names hText]]
  let n = Max(1,Min(m,hChoice+n))
  Self PopUp hChoice Set $n 0
\}

#
#  When a new topic is selected, we set the
#  hShow type-out to displayh it and
#  set the next and prev buttons accordingly.
#
proc hSet \{n\} \{
  variables hShow hText
  set hShow $hText($n)
  Self Button \{hPrev Enable; hNext Enable\}
  if \{$n == 1\} \{Self Button hPrev Disable\}
  if \{$n == [llength [array names hText]]\} \\
    \{Self Button hNext Disable\}
\}

#
#  The Done button makes the window go away.
#
Button hDone -in hbox -at \{4 0\} -title \"Done\" \\
  -command \{Self Window help Disable\}


###############################################
#
#  Here are the pages of help text.  They are
#  stored in an array that corresponds to the
#  menu selections.
#

#
#  Help page 1
#
set hText(1) \\
\{This is the text of the first help
screen.  You can make it as long as you
need, and the typeout will allow you to
scroll it.



See, this is getting longer!





and longer!




That's it.\}

#-----------------------------------------------
#
#   Help page 2
#
set hText(2) \\
\{Here is the second page.  It's pretty\\
short, but gets the idea across.  If you put\\
slashes at the end of the lines, like we do\\
here, then the paragraphs will wrap automatically.\\
If the user enlarges the window, they will fill\\
up the extra space!  Compare this to the previous\\
page, which has hard carriage returns.\}

#-----------------------------------------------
#
#   Help page 3
#
set hText(3) \\
\{Click the DONE button when you are\\
through with help.\}

##################################################

#
#  Here we set the initial message that is showing
#
set hShow $hText($hChoice)

#
#  This help button will bring up the help screen.
#  You will need to place it in the appropriate
#  window in your own control panel.
#
#  It first sets the menu choice to the first page,
#  but you could have several help buttons, and
#  they could each set a different page.  The
#  raise command makes sure the window is on top,
#  even if it is already enabled.
#
Button Help -simpletitle \\
  -command \{
    Self PopUp hChoice Set 1 0
    Self Window help Enable
    raise [Self Window help WidgetName]
  \}
}
  {hide 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}

####################

::class::Group Create Misc-4 {
  {#
#  This example shows how you can hide one or
#  more widgets by placing them in a frame
#  that is disabled.
#

Window controls -rows \{1 1\} -columns \{1 0 1\}
Frame show -in controls -at \{0 1 3 1\} \\
  -relief ridge -bd 4

#
#  These are the widgets we will hide
#
TypeIn a \{\} -in show -at \{0 0\}
Slider b 0 1 -width 200 -in show -at \{0 1\}

#
#  This one controls the display of the others
#
CheckBox hide -in controls -at \{1 0\} \\
  -title \"Hide Other Widgets\" -command HideShow

#
#  This procedure enables or disables the
#  frame containing the widgets to hide.
#
proc HideShow \{\} \{
  variable hide
  if \{$hide\} \{Self Frame show Disable\} \\
    else \{Self Frame show Enable\}
\}}
  {selected 1 each}
  {{set z} 0 0 {{{1 0 0} 50 Red} {{1 .5 0} 0     Orange} {{1 1 0} 50 Yellow} {{0 1 0} 50 Green} {{0 1 1} 50 Cyan} {{0 0 1} 50 Blue} {{1 0 1} 50 Purple} {{0 0 0} 0      Black} {{1 1 1} 0      White}} 1}
  {flat 1.0 1 1 0 0 0 0 0 0 0 0 1.0 1}
  {{} {}}
}
