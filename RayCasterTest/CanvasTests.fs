module CanvasTests

open System
open Xunit
open RayCasterEngine

[<Fact>]
let ``Creating a canvas`` () =
    let c = Canvas (10, 20)
    let f = fun pixel -> pixel = Color (0.0, 0.0, 0.0)
    let blackPixels = c.PixelGrid |> Seq.cast<Color> |> Seq.filter f |> Seq.length

    (c.Width = 10 && c.Height = 20 && blackPixels = c.PixelGrid.Length)
    |> Assert.True

[<Fact>]
let ``Writing pixels to a canvas`` () =
    let c = Canvas (10, 20)
    let red = Color (1.0, 0.0, 0.0)
    let x, y = (2, 3)
    c.WritePixel(x, y, red)

    c.GetPixel(2, 3) = red
    |> Assert.True