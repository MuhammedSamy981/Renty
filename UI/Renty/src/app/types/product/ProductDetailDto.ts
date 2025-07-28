
import { CategoryDto } from "../category/CategoryDto";
import { ImageDto } from "../image/ImageDto";
import { RatingDto } from "../rating/RatingDto";
import { UserDetailDto } from "../user/UserDetailDto";

export interface ProductDetailDto {
  id: number;
  name: string;
  price: number;
  category: CategoryDto | null;
  images: ImageDto[] | null;
  ratings: RatingDto[] | null;
  description: string;
  status: string;
  user: UserDetailDto | null;
  addingDate: string;
}

