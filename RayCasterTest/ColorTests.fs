module ColorTests

open System
open Xunit
open RayCasterEngine

[<Fact>]
let ``Colors are (red, green, blue) tuples`` () =
    let red, green, blue = (-0.5, 0.4, 1.7)
    let color = Color (red, green, blue)
    
    (red = color.Red && green = color.Green && blue = color.Blue)
    |> Assert.True

[<Fact>]
let ``Adding colors`` () =
    let c1 = Color (0.9, 0.6, 0.75)
    let c2 = Color (0.7, 0.1, 0.25)
    
    c1 + c2 = Color (1.6, 0.7, 1.0)
    |> Assert.True

[<Fact>]
let ``Subtracting colors`` () =
    let c1 = Color (0.9, 0.6, 0.75)
    let c2 = Color (0.7, 0.1, 0.25)

    c1 - c2 = Color (0.2, 0.5, 0.5)
    |> Assert.True

[<Fact>]
let ``Multiplying colors`` () =
    let c1 = Color (1.0, 0.2, 0.4)
    let c2 = Color (0.9, 1.0, 0.1)

    c1 * c2 = Color (0.9, 0.2, 0.04)
    |> Assert.True