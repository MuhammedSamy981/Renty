import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories.service';
import { CategoryDto } from 'src/app/types/category/CategoryDto';

@Component({
  selector: 'app-remove-category',
  templateUrl: './remove-category.component.html',
  styleUrls: ['./remove-category.component.css']
})
export class RemoveCategoryComponent implements OnInit {
  categories?: CategoryDto[];
  
  constructor(private categoriesService: CategoriesService) { }

  ngOnInit(): void {
        this.categoryForm.controls.category.disable();

    this.categoriesService.getAll().subscribe({
      next: (categories) => {
        this.categories = categories;
        console.log(this.categories);
              this.categoryForm.controls.category.enable();
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

  categoryForm = new FormGroup({
    category: new FormControl<number>(0, [
      Validators.required,
    ]),
    });
  
  RemoveCategory(e: Event): void {
      e.preventDefault();
      if (this.categoryForm.invalid) return;
    
      this.categoriesService.delete(this.categoryForm.value.category!).subscribe({
        next: () => {
         alert("Deleted successfully");
             window.location.reload();
        },
        error: () => {
          alert('Deleted failed');
        }
      })
    }
  
}
