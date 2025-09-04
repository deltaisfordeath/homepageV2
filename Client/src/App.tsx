import Home from "./components/Home.tsx";
import {Route, Routes} from "react-router";

function App() {
  return (
      <Routes>
          <Route index element={<Home />} />
          
          {/*<Route path="blog">*/}
          {/*    <Route index element={<BlogIndex />} />*/}
          {/*    <Route path=":article" element={<BlogArticle />} />*/}
          {/*    <Route path="trending" element={<Trending />} />*/}
          {/*</Route>*/}
      </Routes>
  )
}

export default App
