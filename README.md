# MHT- MICROSOFT HACK TOGETHER

[![Hackathon][badge_hackathon]][link_hackathon]
[![GitHub Issues][badge_issues]][link_issues]
[![GitHub Stars][badge_repo_stars]][link_repo]
[![Repo Language][badge_language]][link_repo]
[![Repo License][badge_license]][link_repo]

## Project Details

I have created an application (for this event needs I am using .NET/Blazor) which will allow me to see instantly if person I am looking will be available soon - and if someone will be available I will show the time slots when there is possibility to reach out with option to quick message on teams/e-mail with some simple message.

### Purpose
Nowadays I am usually checking folks calendars and I am trying to see when they will be able to talk with me. It is usually time consuming. I just wanted to have compact overview of my week and also ability to quickly check availability of my colleges.

### Project structure
Project structure is looking standard. There are few additional folders with business logic. Here is the solution structure:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/4c38cbbafcb7ff5fc6efc9e3afa2308f060c1f74/MHT/wwwroot/flow_images/project_structure.png?raw=true"> 
</p>

From SDK point of view most important are `Factories`, `Providers` and `Services` under `Infrastructure`.

### Branching strategy
There is standard git flow implemented with `RELEASE` (will be created for first release), `MASTER`, `DEVELOPEMENT` and `FEATURE` branches. 

### Future plans
My plan after this hack is to incorporate this feature to the MS Teams in the end to actually use it on daily basis. 

### Flow description

First thing user will see is login page: 

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/fa5b1db52f9fddc3fe390ffe62646caf5a6f39fc/MHT/wwwroot/flow_images/og_in_page.png?raw=true"> 
</p>

When log-in process will be finised - user will see the view with upcoming meetings:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/3_incoming_events_in_app.png?raw=true"> 
</p>

And here is screen dump from the outlook calendar - events are aligned as it is shown: 

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/2_calendar_outllok_after_login_page.png?raw=true"> 
</p>

What is important here are borders for each event. There are three categories: 
- `RED` : It means, that meeting will take place in less than one day; 
- `YELLOW` : Meeting will take place beetwen tommorow or day after tommorw;
- `GREEN` : Meeting will take place after more than two days;

After clicking "Check presence" in the navbar, user will be moved to new page with search:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/5_search_coworkers_result.png?raw=true"> 
</p>

In this step, there is "*Gu*" in searchbox. What application is doing here - it is calling graph with search term to find people in logged-in user organization. Borders for users are suggesting, that they are offline. 

Below example of the same result after changing users statuses:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/6_status_show_for_search_coworker.png?raw=true"> 
</p>

*Box on user card is showing meetings schedule for the user (for now it is mocked data due to some problems with fetchin particular user calendar and events. I have raised question in QA section.)*

Now, let's click "*Teams*" button and try to send message to active user: 

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/7_send_teams_message_click.png?raw=true"> 
</p>

Results of sending the message:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/9_success_message_to_pradeep.png?raw=true"> 
</p>

Now, let's try to do same thing for an e-mail:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/8_send_outllok_message.png?raw=true"> 
</p>

Results of sending an e-mail:

<p align="center" width="100%">
    <img width="100%" src="https://github.com/KamilSiebyla/MHT/blob/11896ce7b10aa4d8cfbcfddb09a6a5f2c0c956d7/MHT/wwwroot/flow_images/10_success_mail_to_pradeep.png?raw=true"> 
</p>

This is basically whole flow. It is allowing to have quick overview of our and our collegues presences and effectivelly start dialog when we want to have a word with a particular person. 

## Author

👤 Kamil Siebyła

[![LinkedIn][badge_linkedin]][link_linkedin]

[badge_hackathon]: https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft
[link_hackathon]: https://github.com/microsoft/hack-together
[link_linkedin]: https://www.linkedin.com/in/kamilsiebyla
[badge_linkedin]: https://img.shields.io/badge/LinkedIn-KamilSiebyła-blue?style=for-the-badge&logo=linkedin
[badge_language]: https://img.shields.io/badge/language-C%23-blue?style=for-the-badge
[badge_license]: https://img.shields.io/github/license/KamilSiebyla/MHT?style=for-the-badge
[badge_issues]: https://img.shields.io/github/issues/KamilSiebyla/MHT?style=for-the-badge
[badge_repo_stars]: https://img.shields.io/github/stars/KamilSiebyla/MHT?logo=github&style=for-the-badge
[link_issues]: https://github.com/KamilSiebyla/MHT/issues
[link_repo]: https://github.com/KamilSiebyla/MHT
[link_actions]: https://github.com/KamilSiebyla/MHT
