module Canvas

///<summary>A color define as 4 values red, green, blue, and alpha.</summary>
type color

val red : color
val green : color
val blue : color
val yellow : color
val lightgrey : color
val white : color
val black : color

///<summary>A font defined by a font name and its size in dots-per-inch (dpi).</summary>
type Font
///<summary>A collection of font variations specified by the family name.</summary>
type FontFamily

///<summary>Represents the size of a picture, defined by x1,y1,x2,y2 where x2>x1 and y2>y1.</summary>
type Rectangle = float*float*float*float

///<summary>Represents the size of a picture, defined by its width and height.</summary>
type Size = float*float

///<summary>Represents one of the events: KeyDown, TimerTick, MouseButtonDown, MouseButtonUp, and MouseMotion.</summary>
type Event =
    | KeyDown of int
    | TimerTick
    | MouseButtonDown of int * int // x,y
    | MouseButtonUp of int * int // x,y
    | MouseMotion of int * int * int * int // x,y, relx, rely


///<summary>A tree of graphics primitives, define as a tree of graphics primitives.</summary>
type PrimitiveTree

///<summary>A picture.</summary>
type Picture

///<summary>An alignh position-value for aligning boxes along their top edge.</summary>
val Top: float
///<summary>An alignv position-value for aligning boxes along their left edge.</summary>
val Left: float
///<summary>An alignh and alignv position-value for aligning boxes along their center.</summary>
val Center: float
///<summary>An alignh position-value for aligning boxes along their bottom edge.</summary>
val Bottom: float
///<summary>An alignv position-value for aligning boxes along their right edge.</summary>
val Right: float

///<summary>The list of names of available system fonts.</summary>
val systemFontNames: string list

///<summary>An empty graphics primitive tree.</summary>
val emptyTree: PrimitiveTree

/// <summary>
/// Retrieves a FontFamily of a given name.
/// </summary>
/// <param name="name">The name of the font family to retrieve.</param>
/// <returns>The FontFamily corresponding to the specified name.</returns>
val getFamily: name: string -> FontFamily

/// <summary>
/// Creates a Font object using the given family name and size.
/// </summary>
/// <param name="fam">The name of the font family to use.</param>
/// <param name="size">The size of the font.</param>
/// <returns>The newly created Font object.</returns>
val makeFont: fam: string -> size: float -> Font

/// <summary>
/// Measures the size of the given text when rendered with the specified font.
/// </summary>
/// <param name="f">The font used to render the text.</param>
/// <param name="txt">The text to measure.</param>
/// <returns>A tuple representing the width and height of the measured text.</returns>
val measureText: f: Font -> txt: string -> (float * float)

/// <summary>
/// Creates a PrimitiveTree representing the given text with specified properties.
/// </summary>
/// <param name="c">The color of the text.</param>
/// <param name="sw">The stroke width of the text.</param>
/// <param name="f">The font used to render the text.</param>
/// <param name="txt">The text to render.</param>
/// <returns>A PrimitiveTree object representing the rendered text.</returns>
val text: c: color -> sw: float -> f: Font -> txt: string -> PrimitiveTree

///<summary>Retrieves the size of a given graphic primitive tree.</summary>
///<param name="p">The graphic primitive tree for which to get the size.</param>
///<returns>The bounding box of the tree as x1,y1,x2,y2 where x2>x1 and y2>y1.</returns>
val getRectangle : p: PrimitiveTree -> Rectangle

///<summary>Converts a rectangle into a size.</summary>
///<param name="rect">The bounding box as a rectangle x1,y1,x2,y2 where x2>x1 and y2>y1.</param>
///<returns>The width and height of the bounding box.</returns>
val getSize : rect:Rectangle -> Size

///<summary>Translates a given graphic primitive tree by the specified distances along the x and y axes.</summary>
///<param name="dx">The distance to translate the graphic primitive tree along the x-axis.</param>
///<param name="dy">The distance to translate the graphic primitive tree along the y-axis.</param>
///<param name="p">The graphic primitive tree to be translated.</param>
///<returns>A new graphic primitive tree object that is translated by the specified distances.</returns>
val translate : dx:float -> dy:float -> p: PrimitiveTree -> PrimitiveTree 

///<summary>Scales a given graphic primitive tree by the specified factors along the x and y axes.</summary>
///<param name="sx">The scaling factor along the x-axis.</param>
///<param name="sy">The scaling factor along the y-axis.</param>
///<param name="p">The graphic primitive tree to be scaled.</param>
///<returns>A new graphic primitive tree object that is scaled by the specified factors.</returns>
val scale: sx:float -> sy:float -> p: PrimitiveTree -> PrimitiveTree 

///<summary>Rotates a given graphic primitive tree by the specified angle in radians around a point.</summary>
///<param name="x">The x-coordinate of the point around which to rotate.</param>
///<param name="y">The y-coordinate of the point around which to rotate.</param>
///<param name="rad">The angle in radians to rotate the graphic primitive tree.</param>
///<param name="p">The graphic primitive tree to be rotated.</param>
///<returns>A new graphic primitive tree object that is rotated by the specified angle.</returns>
val rotate: x:float -> y:float -> rad:float -> p: PrimitiveTree -> PrimitiveTree 

///<summary>Creates a piecewise affine transformation on a graphic primitive tree.</summary>
///<param name="c">The color to be used.</param>
///<param name="sw">The stroke width.</param>
///<param name="lst">The list of control points for the transformation.</param>
///<returns>A new graphic primitive tree object representing the transformed graphic primitive tree.</returns>
val piecewiseaffine: c:color -> sw: float -> lst:(float*float) list -> PrimitiveTree 

///<summary>Creates a filled polygon with the specified vertices.</summary>
///<param name="c">The color of the polygon.</param>
///<param name="lst">The list of vertices of the polygon.</param>
///<returns>A new graphic primitive tree object representing the filled polygon.</returns>
val filledpolygon: c:color -> lst:(float*float) list -> PrimitiveTree 

///<summary>Creates a rectangle with the specified width, height, and stroke width.</summary>
///<param name="c">The color of the rectangle.</param>
///<param name="sw">The stroke width of the rectangle.</param>
///<param name="w">The width of the rectangle.</param>
///<param name="h">The height of the rectangle.</param>
///<returns>A new graphic primitive tree object representing the rectangle.</returns>
val rectangle: c:color -> sw: float -> w:float -> h:float -> PrimitiveTree 

///<summary>Creates a filled rectangle with the specified width and height.</summary>
///<param name="c">The color of the rectangle.</param>
///<param name="w">The width of the rectangle.</param>
///<param name="h">The height of the rectangle.</param>
///<returns>A new graphic primitive tree object representing the filled rectangle.</returns>
val filledrectangle: c:color -> w:float -> h:float -> PrimitiveTree 

///<summary>Creates an ellipse with the specified radii and stroke width.</summary>
///<param name="c">The color of the ellipse.</param>
///<param name="sw">The stroke width of the ellipse.</param>
///<param name="rx">The horizontal radius of the ellipse.</param>
///<param name="ry">The vertical radius of the ellipse.</param>
///<returns>A new graphic primitive tree object representing the ellipse.</returns>
val ellipse: c:color -> sw:float -> rx:float -> ry:float -> PrimitiveTree 

///<summary>Creates a filled ellipse with the specified radii.</summary>
///<param name="c">The color of the ellipse.</param>
///<param name="rx">The horizontal radius of the ellipse.</param>
///<param name="ry">The vertical radius of the ellipse.</param>
///<returns>A new graphic primitive tree object representing the filled ellipse.</returns>
val filledellipse: c:color -> rx:float -> ry:float -> PrimitiveTree 

///<summary>Places one graphic primitive tree on top of another.</summary>
///<param name="pic1">The first graphic primitive tree, which will be placed on top of the second.</param>
///<param name="pic2">The second graphic primitive tree, over which the first graphic primitive tree will be placed.</param>
///<returns>A new graphic primitive tree object representing the combined image with the first graphic primitive tree on top of the second.</returns>
val onto : pic1: PrimitiveTree -> pic2: PrimitiveTree -> PrimitiveTree 

///<summary>Aligns two graphic primitive trees horizontally at a specific position.</summary>
///<param name="pic1">The first graphic primitive tree to be aligned.</param>
///<param name="pos">The position at which to align the graphic primitive trees along the horizontal axis.</param>
///<param name="pic2">The second graphic primitive tree to be aligned.</param>
///<returns>A new graphic primitive tree object representing the two graphic primitive trees aligned horizontally at the specified position.</returns>
val alignh : pic1: PrimitiveTree -> pos:float -> pic2: PrimitiveTree -> PrimitiveTree 

///<summary>Aligns two graphic primitive trees vertically at a specific position.</summary>
///<param name="pic1">The first graphic primitive tree to be aligned.</param>
///<param name="pos">The position at which to align the graphic primitive trees along the vertical axis.</param>
///<param name="pic2">The second graphic primitive tree to be aligned.</param>
///<returns>A new graphic primitive tree object representing the two graphic primitive trees aligned vertically at the specified position.</returns>
val alignv : pic1: PrimitiveTree -> pos:float -> pic2: PrimitiveTree -> PrimitiveTree 

///<summary>Converts a graphic primitive tree into its string representation.</summary>
///<param name="p">The graphic primitive tree to be converted into a string.</param>
///<returns>A string representing the given graphic primitive tree.</returns>
val tostring : p:PrimitiveTree -> string

///<summary>Generate a color.</summary>
///<param name="r">The amount of red.</param>
///<param name="g">The amount of green.</param>
///<param name="b">The amount of blue.</param>
///<param name="a">The degree to which the color is transparent.</param>
///<returns>A color.</returns>
val fromRgba : r:int -> g:int -> b:int -> a:int -> color

///<summary>Generate a non-transparent color.</summary>
///<param name="r">The amount of red.</param>
///<param name="g">The amount of green.</param>
///<param name="b">The amount of blue.</param>
///<returns>A color.</returns>
val fromRgb : r:int -> g:int -> b:int -> color

///<summary>Creates a Picture object from a given graphic primitive tree.</summary>
///<param name="p">The graphic primitive tree object used to create the graphic primitive tree.</param>
///<returns>A new Picture object representing the given graphic primitive tree.</returns>
val make : p:PrimitiveTree -> Picture

///<summary>Provides a visual explanation of a graphic primitive tree object.</summary>
///<param name="p">The graphic primitive tree object to be explained.</param>
///<returns>A new Picture object representing a visual explanation of the given graphic primitive tree.</returns>
val explain : p:PrimitiveTree -> Picture

///<summary>Draws a picture generated by make or explain to a file with the specified width and height.</summary>
///<param name="width">The width of the output image in pixels.</param>
///<param name="height">The height of the output image in pixels.</param>
///<param name="filePath">The file path where the image will be saved.</param>
///<param name="draw">The picture object to be drawn.</param>
///<returns>A unit value indicating the completion of the operation.</returns>
val renderToFile : width:int -> height:int -> filePath:string -> draw:Picture -> unit

///<summary>Draws a list of pictures generated by make or explain to an animated GIF file with the specified width, height, frame delay, and repeat count.</summary>
///<param name="width">The width of each frame in pixels.</param>
///<param name="heigth">The height of each frame in pixels. (Note: there's a typo in the parameter name; it should likely be "height").</param>
///<param name="frameDelay">The delay between frames in the animation in milliseconds.</param>
///<param name="repeatCount">The number of times the animation should repeat. Use 0 for infinite looping.</param>
///<param name="filePath">The file path where the animated GIF will be saved.</param>
///<param name="drawLst">The list of picture objects to be drawn as frames in the animation.</param>
///<returns>A unit value indicating the completion of the operation.</returns>
val animateToFile : width:int -> height:int -> frameDelay:int -> repeatCount:int -> filePath:string -> drawLst:Picture list -> unit

///<summary>Runs an application with a timer, defining the drawing and reaction functions.</summary>
///<param name="t">The title of the application window.</param>
///<param name="w">The width of the application window in pixels.</param>
///<param name="h">The height of the application window in pixels.</param>
///<param name="interval">An optional interval for the timer in microseconds.</param>
///<param name="draw">A function that takes the current state and returns a Picture object representing the current visual state of the application.</param>
///<param name="react">A function that takes the current state and an Event object and returns an optional new state, allowing the application to react to events.</param>
///<param name="s">The initial state of the application.</param>
///<returns>A unit value indicating the completion of the operation.</returns>
val interact : t:string -> w:int -> h:int -> interval:int option -> draw: ('s -> Picture) -> react: ('s -> Event -> 's option) -> s:'s-> unit

///<summary>Runs an application, defining the drawing function.</summary>
///<param name="t">The title of the application window.</param>
///<param name="w">The width of the application window in pixels.</param>
///<param name="h">The height of the application window in pixels.</param>
///<param name="draw">A function that returns a Picture object representing the current visual state of the application.</param>
///<returns>A unit value indicating the completion of the operation.</returns>
val render : t:string -> w:int -> h:int -> draw: (unit -> Picture) ->  unit
