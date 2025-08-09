dotNET MVC

Run and Debug => Check if its working.

Install Bootstrap :
Run on terminal : 

dotnet tool install -g Microsoft.Web.LibraryManager.Cli
libman install bootstrap@5.3.3 -d wwwroot/lib/bootstrap

Controller : 
Create HelloPageController.cs => Controllers
 Code:
 
 using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class HelloPageController : Controller
    {
        public IActionResult Hello()  // Create a view file, name it Hello.cshtml
        {
            return View();
        }
    }
}

Create View:
Hello.cshtml => HelloPage=> Views

Code:

@{
    Layout = null; //Put this to disconnect Layout design from Shared folder for every new page.
}
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Hello</title>
</head>
<body>
    <h1>Hello World</h1>
    <p>This is a simple Hello page served by HelloPageController.</p>
</body>
</html>

Add Bootstrap link inside the <head> </head>:

<link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />
<script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>

The final code look like : 

@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Hello</title>

    <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />
    <script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>

</head>
<body>
    <h1>Hello World</h1>
    <p>This is a simple Hello page served by HelloPageController.</p>
</body>
</html>

Add css file:

Create hello.css => css => wwwroot

Code :

.box{
    height: 50px;
    width: 50px;
    background-color: blue;
    border: 2px solid black;
    border-radius: 10px;
    display: flex;      
}

Add the css to the page inside the <head> </head>

Code : 
<link rel="stylesheet" href="~/css/hello.css" />

Add a button to test bootstrap

The final code in Hello.cshtml :

@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Hello</title>

    <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />
    <script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="~/css/hello.css" />

</head>
<body>
    <div class="box">
        <p>Hello from the box!</p>
        <h1>Hello World</h1>
        <p>This is a simple Hello page served by HelloPageController.</p>
        <button class="btn btn-primary">Bootstrap Button</button>
    </div>
</body>
</html>


Run and debug : 
Visit : localhost:{PORT}/HelloPage/Hello

Logic : 
Controller name : HelloPage should be same as Folder name inside View folder that is HelloPage

Action name Hello() should be same as the file name Hello.cshtml

The go to /HelloPage/Hello
