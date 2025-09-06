
import { createFileRoute } from '@tanstack/react-router'
import {queryOptions, useSuspenseQuery} from "@tanstack/react-query";
import {getBlogPost} from "../../utilities/api.ts";

const postQueryOptions = (articleUrl: string) => queryOptions({
    queryKey: ['article', articleUrl],
    queryFn: () => getBlogPost(articleUrl),
});

export const Route = createFileRoute('/blog/$article')({
    // 2. The loader gets params and queryClient to pre-fetch the specific post
    loader: ({ params, context: { queryClient } }) =>
        queryClient.ensureQueryData(postQueryOptions(params.article)),
    component: BlogArticle,
});

export default function BlogArticle() {
    const { article: articleUrl } = Route.useParams();
    const {data: article} = useSuspenseQuery(postQueryOptions(articleUrl));
    return <div>
        {article.body}
    </div>
}