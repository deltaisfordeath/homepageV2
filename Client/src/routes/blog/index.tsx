import {useSuspenseQuery} from "@tanstack/react-query";
import {getBlogPosts} from "../../utilities/api.ts";
import {Link} from "@tanstack/react-router";
import {createFileRoute} from '@tanstack/react-router'
import type {BlogArticle} from "../../types";

const postsQueryOptions = {
    queryKey: ['blogArticles'],
    queryFn: getBlogPosts
}

export const Route = createFileRoute('/blog/')({
    loader: ({context: {queryClient}}) =>
        queryClient.ensureQueryData(postsQueryOptions),
    component: BlogIndex,
});

export default function BlogIndex() {
    const {data: blogData} = useSuspenseQuery(postsQueryOptions);

    return <div>
        {blogData.posts.map((article: BlogArticle) =>
            <Link 
                to="/blog/$article"
                params={{ article: article.url }}>{article.title}</Link>
        )}
    </div>
}