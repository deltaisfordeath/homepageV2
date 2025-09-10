import {createRootRouteWithContext, Link, Outlet} from '@tanstack/react-router'
import {TanStackRouterDevtools} from '@tanstack/react-router-devtools'
import '../index.css'
import type {QueryClient} from "@tanstack/react-query";

const RootLayout = () => (
    <>
        <nav className="bg-knavbar pt-1 px-1 shadow-dn">
            <ul className="flex">
                <li>
                    <Link to="/"
                          className="rounded-t-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-kborder/5 hover:text-white [&.active]:bg-kbackground [&.active]:text-white [&.active]:pointer-events-none [&.active]:shadow-up">
                        <div className="logo-icon"></div>
                        <div>Home</div>
                    </Link>
                </li>
                <li>
                    <Link to="/blog"
                          className="rounded-t-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-kborder/5 hover:text-white [&.active]:bg-kbackground [&.active]:text-white [&.active]:pointer-events-none [&.active]:shadow-up">Blog</Link>
                </li>
                {/*<li className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-white/5 hover:text-white">*/}
                {/*    <Link to="/contact" className="[&.active]:font-bold">Contact</Link>*/}
                {/*</li>*/}
            </ul>
        </nav>
        <Outlet/>
        <TanStackRouterDevtools/>
    </>
)

export const Route = createRootRouteWithContext<{ queryClient: QueryClient }>()({
    component: RootLayout,
});