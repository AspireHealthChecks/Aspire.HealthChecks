---
title: Reference Manual
permalink: /reference/
---

The reference manual is now organized as themed chapters instead of mirroring the root README as one large page. Read it in order when you are onboarding a service, or jump directly to the area you are actively integrating.

## Core chapters

1. [Getting Started]({{ '/reference/getting-started/' | relative_url }})
2. [Package Catalog]({{ '/reference/package-catalog/' | relative_url }})
3. [Publishers And Metrics]({{ '/reference/publishers-and-metrics/' | relative_url }})
4. [HealthChecks UI Manual]({{ '/reference/ui-manual/' | relative_url }})
5. [Deployment And Integrations]({{ '/reference/deployment-and-integrations/' | relative_url }})
6. [Tutorials And Samples]({{ '/reference/tutorials/' | relative_url }})
7. [Contributing]({{ '/reference/contributing/' | relative_url }})

## Supporting material

- [Project READMEs]({{ '/reference/readmes/' | relative_url }}) contains generated pages for package, extension, and sample README files that live outside `docs/`.
- [Documentation guides]({{ '/guides/' | relative_url }}) contains operational articles for Docker, webhooks, branding, and Kubernetes.

## Suggested reading paths

- If you are integrating health checks into a service for the first time, start with [Getting Started]({{ '/reference/getting-started/' | relative_url }}) and then continue to [Package Catalog]({{ '/reference/package-catalog/' | relative_url }}).
- If you are rolling out the dashboard, jump to [HealthChecks UI Manual]({{ '/reference/ui-manual/' | relative_url }}) and then use the related guides.
- If you are wiring telemetry export, open [Publishers And Metrics]({{ '/reference/publishers-and-metrics/' | relative_url }}).
- If you are targeting containers, Kubernetes, Azure DevOps, or protected dashboards, open [Deployment And Integrations]({{ '/reference/deployment-and-integrations/' | relative_url }}).

The generated README catalog remains available as appendix material, but the reference manual is now the primary narrative entry point for this site.
Use the README appendix when you need package-level edge cases, but start from these chapters when you want the supported integration path.
