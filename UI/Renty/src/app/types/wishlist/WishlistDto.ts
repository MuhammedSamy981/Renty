import { ProductDto } from "../product/ProductDto";

export interface WishlistDto {
    id: string | null;
    products: ProductDto[] | null;
}
