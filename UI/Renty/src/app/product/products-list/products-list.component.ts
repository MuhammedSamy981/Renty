import { AfterContentInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocationService } from 'src/app/services/location.service';
import { ProductsService } from 'src/app/services/products.service';
import { UsersService } from 'src/app/services/users.service';
import { WishlistsService } from 'src/app/services/wishlists.service';
import { Filters } from 'src/app/types/Filters';
import { ProductDto } from 'src/app/types/product/ProductDto';
import { WishlisUpdateOrCreateDto } from 'src/app/types/wishlist/WishlisUpdateOrCreateDto';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit, AfterContentInit {

  products?: ProductDto[];
  totalRatings: number = 0;
  currentPage: number = 1;
  sizeOfPage: number = 6;
  paginatedProducts: ProductDto[] = [];
  city?: string;
  userId?: string;


  constructor(
    private usersService:UsersService,
    private locationService: LocationService,
    private productsService: ProductsService,
    private wishlistsService: WishlistsService,
    private router: Router) { }

  ngAfterContentInit(): void {
    sessionStorage.setItem("productName", "undefined");
    sessionStorage.setItem("categoryId", "0");
    sessionStorage.setItem("areaId", "0");
  }

  ngOnInit() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(async (position) => {
        this.city = await this.locationService
          .getCityFromCoordinates(position.coords.latitude, position.coords.longitude);
        console.log(position.coords.latitude + "," + position.coords.longitude);
      });
      this.usersService.isLoggedIn().subscribe(logIn=>
        (logIn==true)?this.userId =  this.usersService.getUserId():this.userId);
  
         const productName=sessionStorage.getItem("productName");
         const categoryId=sessionStorage.getItem("categoryId");
         const areaId=sessionStorage.getItem("areaId");
         console.log(productName+"....."+categoryId+"..........."+areaId);

        const filters: Filters =
        {
          productName: productName==null? "undefined" :productName!,
          categoryId: categoryId as any,
          areaId: areaId as any,
        };

        this.productsService.getAllFiltered(filters).subscribe(
          {
            next: (products) => {
              this.products = products;
              console.log(this.products);
            },
            error: (error) => {
              console.error('Calling API failed', error);
            },
          });
      
    }

    else {
      console.log("geolocation isn't supported by this browser");
    }
  }

  GetData(paginatedData: any[]) {
    this.paginatedProducts = paginatedData;
    console.log(this.paginatedProducts);
  }


  AddBookmark(productId: number) {
     if(this.usersService.isLoggedIn())
    { 
    const productToAdd: WishlisUpdateOrCreateDto =
    {
      id: this.userId!,
      productIds: [productId]
    };

    this.wishlistsService.getById(productToAdd.id!).subscribe
      ({
        next: (wishlist) => {
          if(wishlist!=null){
            const product=wishlist.products?.find(p => p.id == productId);
          if (product == undefined) {
           this.addToWishList(productToAdd);
        }
        else
        {
          console.log("repeated");
        }
          }
          else {
             this.addToWishList(productToAdd);
          }
        },
               error: () => {
                console.log("failed");
              },
      })
      }

         else
         {
           this.router.navigateByUrl("/Login");
         }
       }


       addToWishList(productToAdd: WishlisUpdateOrCreateDto):void
       {
              this.wishlistsService.addToList(productToAdd).subscribe({
        next: () => {
         alert("Added successfully")
        },
        error: () => {
          alert('Added failed');
        },
            }
          )
       }


}
