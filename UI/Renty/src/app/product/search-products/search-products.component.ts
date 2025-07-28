import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-search-products',
  templateUrl: './search-products.component.html',
  styleUrls: ['./search-products.component.css']
})
export class SearchProductsComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute,private router:Router) {}

  ngOnInit(): void {
 
    this.activatedRoute.params.subscribe((params)=>
    { 
      sessionStorage.setItem("productName",params['productName']);
      sessionStorage.setItem("categoryId",params['category']);
      sessionStorage.setItem("areaId",params['area']);
      console.log("---------------"+params['destination']);
      if(params['destination']=="admin")
        {
            this.router.navigateByUrl("/admin/product");
        }
      else
      {
        this.router.navigateByUrl("/product");
      }
    });
  }
}