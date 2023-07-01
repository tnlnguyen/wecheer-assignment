import { BaseModel } from "../core/domain/base.model";

export interface ImageEntity extends BaseModel {
	imageUrl: string,
	description: string,
	count: number,
}