module PortablePixmapWriterTests

open System
open Xunit
open RayCasterEngine

[<Fact>]
let ``Constructing the PPM header`` () =
    let c = Canvas (5, 3)
    let ppm = PortablePixmapWriter.CanvasToPPM (c)
    let lines = ppm.Split "\n"

    (lines.[0] = "P3" && lines.[1] = "5 3" && lines.[2] = "255")
    |> Assert.True

[<Fact>]
let ``Contructing the PPM pixel data`` () =
    let canvas = Canvas (5, 3)
    let color1 = Color (1.5, 0.0, 0.0)
    let color2 = Color (0.0, 0.5, 0.0)
    let color3 = Color (-0.5, 0.0, 1.0)
    
    canvas.WritePixel(0, 0, color1)
    canvas.WritePixel(2, 1, color2)
    canvas.WritePixel(4, 2, color3)
    let ppmLines = PortablePixmapWriter.CanvasToPPM(canvas).Split "\n"

    (ppmLines.[3] = "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0" &&
     ppmLines.[4] = "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0" &&
     ppmLines.[5] = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255​")
     |> Assert.True

// [<Fact>]
// let ``Splitting long lines in PPM files`` () =
//     let canvas = Canvas (10, 2)
//     let color = Color (1.0, 0.8, 0.6)
//     canvas.WriteAllPixels (color)
//     let ppmLines = PortablePixmapWriter.CanvasToPPM(canvas).Split "\n"

//     (ppmLines.[3] = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204​" &&
//      ppmLines.[4] = "153 255 204 153 255 204 153 255 204 153 255 204 153​" &&
//      ppmLines.[5] = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204" &&
//      ppmLines.[6] = "153 255 204 153 255 204 153 255 204 153 255 204 153")
//      |> Assert.True

// [<Fact>]
// let ``PPM files are terminated by a newline character`` () =
//     let canvas = Canvas (5, 3)
//     let ppm = PortablePixmapWriter.CanvasToPPM(canvas)
//     let test = ppm.Length

//     ppm.[ppm.Length - 2..ppm.Length] = "\n"
//     |> Assert.True

