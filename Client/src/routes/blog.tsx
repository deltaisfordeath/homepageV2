import { createFileRoute, Outlet } from '@tanstack/react-router';

// This is the layout component for the /blog section
function BlogComponent() {
    return (
        <div>
            <h2 className="text-2xl font-bold mb-4">My Awesome Blog</h2>
            <hr className="my-4" />
            {/* Child routes will be rendered here */}
            <Outlet />
        </div>
    );
}

export const Route = createFileRoute('/blog')({
    component: BlogComponent,
});