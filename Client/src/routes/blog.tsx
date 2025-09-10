import { createFileRoute, Outlet } from '@tanstack/react-router';

function BlogComponent() {
    return (
        <div className="container mx-auto">
            <h2 className="text-2xl font-bold my-4">My Awesome Blog</h2>
            {/* Child routes will be rendered here */}
            <Outlet />
        </div>
    );
}

export const Route = createFileRoute('/blog')({
    component: BlogComponent,
});