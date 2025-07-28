import { Component, OnInit } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {

 categories?:any[];

 constructor(private categoriesService:CategoriesService)
 {}

  ngOnInit(): void {
    this.categoriesService.getAll().subscribe({
      next:(categories)=> {
        this.categories=categories;
        console.log(this.categories);
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    })
  }

}
