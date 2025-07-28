import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories.service';
import { CategoryAddDto } from 'src/app/types/category/CategoryAddDto';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  
  lastId?:number;
  
  constructor(private categoriesService: CategoriesService) { }

  ngOnInit(): void {
    this.categoriesService.getAll()
    .subscribe({
      next: (categories) => {
        this.lastId = categories.length
        console.log(this.lastId)
       },
       error: (error) => {
         console.error('Calling API failed', error);
       },
  });
  }

  categoryForm = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
      ])
    });
  
  AddCategory(e: Event): void {
      e.preventDefault();
      if (this.categoryForm.invalid) return;

      const category: CategoryAddDto =
      {
        id: this.lastId!+1,
        name: this.categoryForm.value.name!,
      };
    
      this.categoriesService.add(category).subscribe({
        next: () => {
         alert("Added successfully");
             window.location.reload();
        },
        error: () => {
          alert('Added failed');
        },
      })
    }
  
}
