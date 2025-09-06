import kennyTriathlon from "../img/kenny_triathlon.png"
import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/')({
    component: Index,
})
export default function Index() {
    return <div>
        <div className="flex flex-col items-center mx-auto max-w-screen-lg px-2">
            <section>
                <div className="grid py-8 mx-auto lg:gap-8 xl:gap-0 lg:py-16 lg:grid-cols-12">
                    <div className="mr-auto place-self-center lg:col-span-7">
                        <h1 className="max-w-2xl mb-4 text-4xl font-extrabold tracking-tight leading-none md:text-5xl xl:text-6xl dark:text-white">Welcome
                            to my homepage!</h1>
                        <h2 className="max-w-2xl mb-4 text-2xl font-extrabold tracking-tight leading-none md:text-3xl xl:text-4xl dark:text-white">My
                            name is Kenny.</h2>
                        <p className="max-w-2xl mb-6 lg:mb-8 text-lg lg:text-xl">I'm an insatiable tech enthusiast (much
                            to my wife and my bank account's dismay).</p>
                    </div>
                    <div className="hidden lg:mt-0 lg:col-span-5 lg:flex">
                        <img src={kennyTriathlon} alt="mockup"/>
                    </div>
                </div>
            </section>
            <p className="pb-5 max-w-prose indent-6">Writing code feels like alchemy; creating interactive,
                almost-tangible web applications out of nothing but thoughts and keystrokes. I also 'enjoy' endurance
                sports such as triathlons and marathons, because subjecting yourself to <a
                    href="https://www.goodreads.com/quotes/168105-eat-a-live-frog-first-thing-in-the-morning-and">voluntary
                    suffering</a> makes you realize that most of the challenges you face in day-to-day life really
                aren't all that bad.</p>
            <p className="pb-5 max-w-prose indent-6">
                I've been fascinated with electronics since the first time my dad brought home a desktop computer when I
                was a child. The computer ran on MS-DOS, couldn’t connect to the internet or play videos, or do anything
                else that should have caught the attention of a five-year-old boy. Yet somehow that machine drew me in;
                it had an inexplicable, monumental presence about it. That impression has stuck with me my entire life.
            </p>
            <p className="pb-5 max-w-prose indent-6">
                By the time I was 12 I managed to get my hands on all the parts needed to build my own desktop. I had a
                copy of Windows 98 ready to go, but it turned out merely assembling the machine was the easy part. We
                had internet access by this point, but the internet back then was disorganized and hard to navigate.
                There was no YouTube to look up simple tutorials. I had to read through the owner’s manual of my
                motherboard to learn about setting the boot order in BIOS and using the jumper pins on the hard drive
                and CD-ROM to designate primary and secondary devices.
            </p>
            <p className="pb-5 max-w-prose indent-6">
                Finally getting that computer to boot into Windows 98 turned out to be a long, long process with many
                breakthroughs and setbacks. But I was determined, or perhaps obsessed, and I never saw failure as an
                option. This drive has persisted in me through adulthood.
            </p>
            <p className="pb-5 max-w-prose indent-6">
                The internet has come a long way from those days of 56k dial-up, America Online free trial CDs, and
                highly ineffective search engines. Yet the potential of the internet is still barely being realized.I'm
                very excited to see how technologies like blockchain, generative AI, and web assembly will shape the
                future. I will work hard to contribute as much as I can to bringing about the next generation of web
                services.
            </p>
        </div>
    </div>
}