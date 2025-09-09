import {QueryClient} from "@tanstack/react-query";

export type Entity<T> = T extends infer U ? { [K in keyof U]: U[K] } : never;

export interface MyRouterContext {
    queryClient: QueryClient;
}

export type BlogSummaryItem = {
    title: string;
    createdAt: string;
    updatedAt: string;
    viewCount: number;
    url: string;
}

export type BlogArticle = Entity<BlogSummaryItem & {
    body: string;
}>

export interface BlogResponse {
    pageIndex: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;
    posts: BlogArticle[];
}