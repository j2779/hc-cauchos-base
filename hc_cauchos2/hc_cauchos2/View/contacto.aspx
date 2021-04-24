<%@ Page Title="" Language="C#" MasterPageFile="~/View/Principal.master" AutoEventWireup="true" CodeFile="~/Controller/contacto.aspx.cs" Inherits="View_contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
          #contatti{
      background-color: #fff;
      letter-spacing: 2px;
      }
        #contatti a{
          color: #fff;
          text-decoration: none;
        }


        @media (max-width: 575.98px) {

          #contatti{padding-bottom: 800px;}
          #contatti .maps iframe{
            width: 100%;
            height: 450px;
          }
         }


        @media (min-width: 576px) {

           #contatti{padding-bottom: 800px;}

           #contatti .maps iframe{
             width: 100%;
             height: 450px;
           }
         }

        @media (min-width: 768px) {

          #contatti{padding-bottom: 350px;}

          #contatti .maps iframe{
            width: 100%;
            height: 850px;
          }
        }

        @media (min-width: 992px) {
          #contatti{padding-bottom: 200px;}

           #contatti .maps iframe{
             width: 100%;
             height: 700px;
           }
        }


        #author a{
          color: #fff;
          text-decoration: none;
    
        }

        #map{
           box-shadow: 2px 2px 20px #000000;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" integrity="sha384-+d0P83n9kaQMCwj8F4RJB66tzIwOKmrdb46+porD/OvrJ+37WqIM7UoBtwHO6Nlg" crossorigin="anonymous">

<div class="row" id="contatti">
    <div class="container mt-5" >
        <div class="row" style="height:550px;">
          <div class="col-md-6 maps" >
              <h2 class="text-danger"><strong>Nuestra Ubicacion</strong></h2>
             <iframe id="map" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7951.481350545098!2d-74.35757187866818!3d4.814529536015057!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x18c080e231ee05e8!2sArte%20%26%20Maderas!5e0!3m2!1ses!2sco!4v1584748339937!5m2!1ses!2sco" frameborder="0" style="border:0;" allowfullscreen></iframe>
          </div>
          <div class="col-md-6 ">
              <br />
              <br />
              <div align="center">
                  <img class=" img-thumbnail mx-auto d-block" src="../ima/porusted.png" alt="Alternate Text" />
              </div>
              <hr />
              <br />
            <div class="text-dark text-center">
            <h2 class="text-uppercase mt-4 font-weight-bold text-danger">Contactanos</h2>

            <i class="fas fa-phone mt-3"></i> <a class="text-dark" href="tel:+">(+57) 3042137104</a><br>
            <i class="fas fa-phone mt-3"></i> <a class="text-dark" href="tel:+">(+57) 3219967652</a><br>
            <i class="fa fa-envelope mt-3"></i> <a class="text-dark" href="">hc_cauchos@gmail.com</a><br>
            <i class="fas fa-globe mt-3"></i> Www.HC-Cauchos.com<br>
            <div class="my-4">
            <a href=""><i class="fab fa-facebook fa-3x pr-4"></i></a>
            <a href=""><i class="fab fa-linkedin fa-3x"></i></a>
            </div>
            </div>
          </div>

        </div>
    </div>
</div>
    <br />
    <br />
</asp:Content>

