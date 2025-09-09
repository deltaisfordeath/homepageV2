import type {BlogArticle, BlogResponse} from "../types";

async function fetchOrThrowError(request: Function) {
    const response = await request();
    if (!response.ok) {
        throw new Error(`${response.statusCode} - ${response.statusText}`);
    }
    return response.json();
}

export async function getBlogPosts(): Promise<BlogResponse> {
    return fetchOrThrowError(() => fetch("/api/blog"));
}

export async function getBlogPost(postUrl: string): Promise<BlogArticle> {
    return fetchOrThrowError(() => fetch('/api/blog/' + postUrl));
}