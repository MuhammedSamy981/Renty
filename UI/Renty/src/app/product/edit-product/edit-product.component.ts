import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService } from 'src/app/services/categories.service';
import { ImagesService } from 'src/app/services/images.service';
import { ProductsService } from 'src/app/services/products.service';
import { UsersService } from 'src/app/services/users.service';
import { CategoryDto } from 'src/app/types/category/CategoryDto';
import { ImageUpdateDto } from 'src/app/types/image/ImageUpdateDto';
import { ProductUpdateDto } from 'src/app/types/product/ProductUpdateDto';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent  implements OnInit {

  currentUserId?:string

  productId?:number;

  categories?:CategoryDto[];

  isImage1Loaded:boolean=true;

  isImage2Loaded:boolean=true;

  isImage3Loaded:boolean=true;

  isImage4Loaded:boolean=true;



  //images inputs
 selectedFiles: FileList[]=[];
 currentFile?: File;
 preview:string='';
 previews:string[]=[];
 imagesIds:number[]=[];


 constructor(private productsService:ProductsService,
  private imagesService:ImagesService,
  private categoriesService:CategoriesService,
  private activatedRoute:ActivatedRoute,
  private router:Router,private usersService:UsersService
  ){}

ngOnInit(): void {
  
 this.currentUserId=this.usersService.getUserId();

 this.editProductForm.controls.name.disable();
    this.editProductForm.controls.price.disable();
    this.editProductForm.controls.category.disable();
    this.editProductForm.controls.description.disable();

    this.categoriesService.getAll().subscribe({
      next:(categories)=>{
        this.categories=categories;
        console.log(this.categories);
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    })

    this.activatedRoute.paramMap.subscribe({
      next:(map)=> {
        this.productId=+map.get('id')!;
        this.productsService.getById(this.productId,this.currentUserId!).subscribe({
          next:(productDetailDto)=> {

            const product=
            {
              id: productDetailDto.id!,
              name: productDetailDto.name!,
              category: productDetailDto.category?.id!,
              price: productDetailDto.price!,
              description: productDetailDto.description!,
            };
            this.editProductForm.patchValue(product);

            const images=productDetailDto.images!;
            for(let i=0; i<images?.length!;i++)
            {
               this.imagesIds[i]=images[i].id;
               this.previews[i] = images[i].url as string;
            }
            console.log(productDetailDto.category?.name);
             this.editProductForm.controls.name.enable();
    this.editProductForm.controls.price.enable();
    this.editProductForm.controls.category.enable();
    this.editProductForm.controls.description.enable();
    this.isImage1Loaded=false;
    this.isImage2Loaded=false;
    this.isImage3Loaded=false;
    this.isImage4Loaded=false;
          },
          error:(error)=> {
            console.error('Calling API failed',error);
          },
        })
      },
      error:(error)=> {
        console.error('This service was not found',error);
      },
    });
}




editProductForm = new FormGroup({
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
  
  
editProduct(e:Event):void
{
  e.preventDefault();
  if(this.editProductForm.invalid) return;
  const product:ProductUpdateDto=
  {
    id: this.productId!,
    name: this.editProductForm.value.name!,
    categoryId: this.editProductForm.value.category!,
    price: this.editProductForm.value.price!,
    description: this.editProductForm.value.description!,
    userId:this.currentUserId!,
  };
  this.productsService.update(product).subscribe({
    next:()=> {
       for(let i=0;i<this.previews.length;i++)
        {
           this.storeImages(i,this.productId!);
        }

        alert("Updated successfully")
        this.router.navigateByUrl("/product/management");
      
    },
    error:()=> {
          alert('Updated failed');
    },
  })
}

//images code start

onImageUpload1(event: any): void {
   this.imageUpload(event,0);
}

onImageUpload2(event: any): void {
  this.imageUpload(event,1);
}

onImageUpload3(event: any): void {
this.imageUpload(event,2);
}

onImageUpload4(event: any): void {
this.imageUpload(event,3);
}


imageUpload(event: any,index:number): void {
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
        if(this.previews[index].includes("image")){
          console.log(this.previews[index]);
        }
      };
      reader.readAsDataURL(this.currentFile);
    }
  }
}

storeImages(index:number,productId:number):void
{
  if(!this.previews[index].includes("image"))
  {
     return;
  }
  const image:ImageUpdateDto=
  {
    id: this.imagesIds[index],
    url: this.previews[index] as string,
    productId: productId
    
  };
  this.imagesService.update(image).subscribe({
    next:()=> {
      console.log("image "+(index+1)+" was added");
    },
    error:(err)=> {
      console.error("image "+(index+1)+" was not correct format",err);
    },
   });
}
//images codes end

}
