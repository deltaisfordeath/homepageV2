import { createRootRoute, Link, Outlet } from '@tanstack/react-router'
import { TanStackRouterDevtools } from '@tanstack/react-router-devtools'
import '../index.css'

const RootLayout = () => (
    <>
        <ul className="flex">
            <li className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-white/5 hover:text-white ">
                <Link to="/" className="[&.active]:font-bold">
                    <div className="logo-icon"></div>
                    <div>Home</div>
                </Link>
            </li>
            <li className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-white/5 hover:text-white">
                <Link to="/blog" className="[&.active]:font-bold">Blog</Link>
            </li>
            <li className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-white/5 hover:text-white">
                <Link to="/contact" className="[&.active]:font-bold">Contact</Link>
            </li>
        </ul>
        <Outlet/>
        <TanStackRouterDevtools/>
    </>
)

export const Route = createRootRoute({component: RootLayout})