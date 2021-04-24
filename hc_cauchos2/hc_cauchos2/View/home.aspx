<%@ Page Title="" Language="C#" MasterPageFile="~/View/Principal.master" AutoEventWireup="true" CodeFile="~/Controller/home.aspx.cs" Inherits="View_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
      
          * p {
              font-size:22px;
          }
          
          #galeria img{
	        vertical-align: top;
	        width: 400px;
	        height: 300px;
	        margin: 20px;
	        opacity: 0.6;
	        border: 1px solid #484848;
        }
        #galeria img:hover{
	        border: 1px solid#fff;
	        opacity: 1;
        }
  
      #punto:hover{
          border-color:black;
      }
      #punto1:hover{
          border-color:black;
      }
      #punto2:hover{
          border-color:black;
      }
      #punto3:hover{
          border-color:black;
      }
      #punto4:hover{
          border-color:black;
      }
      #punto5:hover{
          border-color:black;
      }

      #princi img{
          width:auto;
          height:400px;
          box-shadow: 2px 2px 20px #484848;
      }
      #princi img:hover {
          border-color:black;
          border:solid 1px;
      }
      #mision{
          transition:all .6s ease;
          background-color:rgba(0,0,0,0.2);
          box-shadow: 2px 2px 20px #000000;
      }
      #mision:hover{
          background: black;
          color:white;
	      width:350px;
	      transform: rotate(360deg);
      }#mision1{
          transition:all .6s ease;         
          background-color:rgba(249,81,81,0.1);
          box-shadow: 2px 2px 20px #000000;
      }
      #mision1:hover{
          background: black;
          color:white;
	      width:350px;
	      transform: rotate(360deg);
      }#mision2{
          transition:all .6s ease;
          background-color:rgba(0,0,0,0.2);
          box-shadow: 2px 2px 20px #000000;
      }
      #mision2:hover{
          background: black;
          color:white;
	      width:350px;
	      transform: rotate(360deg);
      } 
      #bla{
          box-shadow: 2px 2px 20px #000000;
      }
      #bla1{
          box-shadow: 2px 2px 20px #000000;
      }
      #bla2{
          box-shadow: 2px 2px 20px #000000;
      }

          .auto-style1 {
              font-size: large;
          }



        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header>
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
          <div class="carousel-inner" role="listbox">
            <!-- Slide One - Set the background image for this slide in the line below -->
            <div class="carousel-item active" style="background-image: url('../ima/radia.jpeg')">
              <div class="carousel-caption d-none d-md-block">
              </div>
            </div>
            <!-- Slide Two - Set the background image for this slide in the line below -->
              <div class="carousel-item" style="background-image: url('../ima/coches.png')">
              <div class="carousel-caption d-none d-md-block">
                   <h2 class="text-dark"> <strong>Disponibilidad En Muchas Marcas</strong></h2>
              </div>
            </div>
            <!-- Slide Three - Set the background image for this slide in the line below -->
            <div class="carousel-item" style="background-image: url('../ima/bandas.jpeg')">
              <div class="carousel-caption d-none d-md-block">
              </div>
            </div>
          </div>
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>
      </header>
      <!-- Page Content -->
      <div class="container">
        <h1 id="hc"  ><strong>Bienvenido a HC cauchos</strong></h1>
          <hr />
          <!-- Features Section -->
          <br />
        <div class="row">
          <div class="col-lg-6">
            <h2 class="text-danger"><strong>¿Quienes Somos?</strong></h2>
            <p><strong>HC CAUCHOS</strong> es una empresa encargada de comercializacion de productos(cauchos) destinados al mantenimiento 
                de automiviles, maquinaria o multiples fines. <br /> <br />
                en nuestro productos puede encontrar:
            </p>
            <ul>
              <li class="auto-style1">Soportes para motor y caja</li>
              <li>Mangueras</li>
              <li>Bujes</li>
              <li>Empaques</li>
              <li>Tapete</li>
              <li>correas</li>
              <li>topes</li>
            </ul>
          </div>
          <div id="princi" class="col-lg-6">
            <img class="img-fluid rounded-left" src="../ima/local.png" alt="">
          </div>
        </div>
        <!-- /.row -->
          <hr />
        <!-- Marketing Icons Section -->
          <br />
          <br />
        <div class="row">
          <div class="col-lg-4 mb-4">
            <div id="mision" class="card h-80 ">
              <h4  class="card-header bg-dark text-danger"><strong>MISION</strong></h4>
              <div class="card-body">
                <p class="card-text"><asp:Label ID="LB_mision" runat="server" Text="Label"></asp:Label></p>
              </div>
              <div class="card-footer bg-dark">
              </div>
            </div>
          </div>
          <div class="col-lg-4 mb-4">
            <div id="mision1" class="card h-100">
              <h4 class="card-header bg-danger"><strong>VISION</strong></h4>
              <div class="card-body">
                <p class="card-text"><asp:Label ID="LB_vision" runat="server" Text="Label"></asp:Label></p>
              </div>
              <div class="card-footer bg-danger">
              </div>
            </div>
          </div>
          <div class="col-lg-4 mb-4">
            <div id="mision2" class="card h-100">
              <h4 class="card-header bg-dark text-danger"><strong>OBJETIVOS</strong></h4>
              <div class="card-body">
                <p class="card-text"><asp:Label ID="LB_objetivo" runat="server" Text="Label"></asp:Label></p>
              </div>
              <div class="card-footer bg-dark">
              </div>
            </div>
          </div>
        </div>
          <br />
        <!-- /.row -->
          <hr />
        <!-- Portfolio Section -->        
        <h2 class="text-danger"><strong>Algunos Productos</strong></h2>
          <br />
        <div id="galeria">
            <div class="row"> 
                 <img id="bla" src="../ima/bandas.jpg" alt="" class="rounded float-left col-xl-4">                                             
		         <img id="bla1" src="../ima/soporte5.jpg" alt="" class="rounded mx-auto d-block col-md-3 ">
		         <img id="bla2"src="../ima/2.jpg" alt="" class="rounded float-right col-lg-4">
            </div>

            <div class="row">
               <img id="bla" src="../ima/3.jpg" alt="" class="rounded float-left col-xl-4">                              
		         <img id="bla1" src="../ima/mangue.jpg" alt="" class="rounded mx-auto d-block col-md-3 ">
		         <img id="bla2"src="../ima/manguera.jpg" alt="" class="rounded float-right col-lg-4">
            </div>
        </div>
        <!-- /.row -->
        <hr/>
        <!-- Call to Action Section -->
        <div class="row mb-4">
          <div class="col-md-8">
              <h2>¿DESEAS VER MAS PRODUCTOS Y DETALLES?</h2>
          </div>
          <div class="col-md-4">
            <a class="btn btn-lg btn-secondary btn-block text-danger" href="catalogo.aspx"><strong>Catalogo</strong></a>
          </div>
        </div>
      </div>
      <!-- /.container -->
</asp:Content>

