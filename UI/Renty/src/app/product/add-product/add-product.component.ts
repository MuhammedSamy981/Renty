import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService } from 'src/app/services/categories.service';
import { ImagesService } from 'src/app/services/images.service';
import { ProductsService } from 'src/app/services/products.service';
import { UsersService } from 'src/app/services/users.service';
import { CategoryDto } from 'src/app/types/category/CategoryDto';
import { ImageAddDto } from 'src/app/types/image/ImageAddDto';
import { ProductAddDto } from 'src/app/types/product/ProductAddDto';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  currentUserId?:string;
 currentUserPhoneNumber?: string;
  categories?: CategoryDto[];

  //images inputs
  selectedFiles: FileList[] = [];
  currentFile?: File;
  preview: string = '';
  previews: string[] = [];
 


  constructor(private productsService: ProductsService,
    private imagesService: ImagesService,
    private categoriesService: CategoriesService,
    private router: Router, private usersService: UsersService
  ) { }

  ngOnInit(): void {

       this.currentUserId=this.usersService.getUserId();
       this.currentUserPhoneNumber=this.usersService.getUserPhoneNumber();

          this.addProductForm.controls.category.disable();
    this.categoriesService.getAll().subscribe({
      next: (categories) => {
        this.categories = categories;
           this.addProductForm.controls.category.enable();
        console.log(this.categories);
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })

  }


  addProductForm = new FormGroup({
    name: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    price: new FormControl<number>(0, [
      Validators.required,
      Validators.min(3),
    ]),
    category: new FormControl<number>(0, [
      Validators.min(1),
    ]),
    description: new FormControl<string>('',
      [
        Validators.required,
      ]),
  });


  addProduct(e: Event): void {
    e.preventDefault();
    if (this.addProductForm.invalid) return;
   if(this.currentUserPhoneNumber!="undefined"){
    const product: ProductAddDto =
    {
      name: this.addProductForm.value.name!,
      categoryId: this.addProductForm.value.category!,
      price: this.addProductForm.value.price!,
      description: this.addProductForm.value.description!,
      userId: this.currentUserId!,
    };
      console.log(this.currentUserId+"/"+product
        .userId);
    this.productsService.add(product).subscribe({
      next: () => {
        this.productsService.getAll().subscribe({
          next: (products) => {
           for (let i = 0; i < this.previews.length; i++) {
              this.storeImages(i, products[products.length - 1].id);
            }
          }
        });

        alert("Added successfully");
        this.router.navigateByUrl("/product/management");
      },
      error: () => {
        alert('Added failed');
      },
    })}
    else
    {
      alert("Please modify your account and add your phone number.");
    }
  }

  //images code start

  onImageUpload1(event: any): void {
    this.imageUpload(event, 0);
  }

  onImageUpload2(event: any): void {
    this.imageUpload(event, 1);
  }

  onImageUpload3(event: any): void {
    this.imageUpload(event, 2);
  }

  onImageUpload4(event: any): void {
    this.imageUpload(event, 3);
  }


  imageUpload(event: any, index: number): void {
    this.previews[index] = '';
    this.selectedFiles[index] = event.target.files;
    if (this.selectedFiles[index]) {
      const file: File | null = this.selectedFiles[index].item(0);

      if (file) {
        this.previews[index] = '';
        this.currentFile = file;
        const reader = new FileReader();

        reader.onload = (e: any) => {
          this.previews[index] = e.target.result;
          if (this.previews[index].includes("image")) {
            console.log(this.previews[index]);
          }
        };
        reader.readAsDataURL(this.currentFile);
      }
    }
  }

  storeImages(index: number, productId: number): void {
    if (!this.previews[index].includes("image")) {
      return;
    }
    const image: ImageAddDto =
    {
      url: this.previews[index] as string,
      productId: productId
    };
    this.imagesService.add(image).subscribe({
      next: () => {
        console.log("image " + (index + 1) + " was added");
      },
      error: (err) => {
        console.error("image " + (index + 1) + " was not correct format", err);
      },
    });
  }
  //images codes end

}
