import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AreasService } from 'src/app/services/areas.service';
import { CategoriesService } from 'src/app/services/categories.service';
import { AreaDto } from 'src/app/types/area/AreaDto';
import { CategoryDto } from 'src/app/types/category/CategoryDto';

@Component({
  selector: 'app-products-filters',
  templateUrl: './products-filters.component.html',
  styleUrls: ['./products-filters.component.css']
})
export class ProductsFiltersComponent implements OnInit {

  categories?: CategoryDto[];
  @Input() city?: string;
  areas?: AreaDto[];

  constructor(
        private categoriesService:CategoriesService,
        private areasService: AreasService,private router:Router) {}


  ngOnInit() {    
    this.categoriesService.getAll().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    });

          this.areasService.getAllByCityName(this.city!).subscribe({
            next: (areas) => {
              this.areas = areas;
           },
            error: (error) => {
              console.error('Calling API failed', error);
           },
         });



  }


  search(product: string, category: string, area: string): void {

    console.log(product + "/" + category + "/" + area);
    this.router.navigateByUrl("/product/search/" + category + "/" + area + "/" + product+"/"+" ");
  }
}
