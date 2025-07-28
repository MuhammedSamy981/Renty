import { AfterContentInit, Component, OnInit } from '@angular/core';
import { ProductDto } from '../types/product/ProductDto';
import { CategoryDto } from '../types/category/CategoryDto';
import { CountryDto } from '../types/country/CountryDto';
import { CityDto } from '../types/city/CityDto';
import { AreaDto } from '../types/area/AreaDto';
import { UsersService } from '../services/users.service';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';
import { RatingsService } from '../services/ratings.service';
import { RatingDto } from '../types/rating/RatingDto';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  constructor(private usersService:UsersService,
     private router: Router
    ){}

        logOut():void
      {
        this.usersService.logout();
      this.router.navigateByUrl("/").then(() => {
      window.location.reload();
    });
      }
  }



  


    